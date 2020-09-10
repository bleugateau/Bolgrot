using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Autofac;
using Bolgrot.Core.Ankama.Protocol.Data;
using Bolgrot.Core.Ankama.Protocol.Enums;
using Bolgrot.Core.Ankama.Protocol.Messages;
using Bolgrot.Core.Ankama.Protocol.SendMessages;
using Bolgrot.Core.Ankama.Protocol.Types;
using Bolgrot.Core.Ankama.Protocol.Utils;
using Bolgrot.Core.Common.Entity;
using Bolgrot.Core.Common.Entity.Data;
using Bolgrot.Core.Common.Managers.Pathfinding;
using Bolgrot.Core.Common.Repository;
using Bolgrot.Server.Game.Network;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceStack;

namespace Bolgrot.Server.Game.Managers
{
    public interface IMapManager
    {
        public Task<Map> GetMapById(long id);

        public Task GameMapMovement(GameClient client, GameMapMovementRequestMessage gameMapMovementRequestMessage);

        public Task SendMapInformationsRequest(GameClient client,
            MapInformationsRequestMessage mapInformationsRequestMessage);

        public Task ChangeMap(GameClient client, ChangeMapMessage changeMapMessage);
    }

    public class MapManager : AbstractGameManager, IMapManager
    {
        public ConcurrentDictionary<long, Map> MapsData { get; set; }

        private IPathfinderManager _pathfinderManager;
        private ICharacterRepository _characterRepository;
        private INpcManager _npcManager;

        public MapManager(IPathfinderManager pathfinderManager, ICharacterRepository characterRepository,
            INpcManager npcManager)
        {
            this._logger.Info("MapManager loading...");

            this.MapsData = new ConcurrentDictionary<long, Map>();
            this._pathfinderManager = pathfinderManager;
            this._characterRepository = characterRepository;
            this._npcManager = npcManager;
        }

        /**
         * Manage game map movement request
         */
        public async Task GameMapMovement(GameClient client,
            GameMapMovementRequestMessage gameMapMovementRequestMessage)
        {
            var map = await this.GetMapById(client.Character.MapId);
            if (map == null)
            {
                client.Send(new GameMapNoMovementMessage());
                return;
            }

            var decompressedKeyMovements =
                this._pathfinderManager.DecompressKeyMovements(map, gameMapMovementRequestMessage.keyMovements);

            if ((gameMapMovementRequestMessage.keyMovements.Length - 1) <= 0 ||
                decompressedKeyMovements.Find(x => !x.IsWalkable()) != null)
            {
                client.Send(new GameMapNoMovementMessage());
                return;
            }

            var paths = await this._pathfinderManager.GetPath(map,
                decompressedKeyMovements[decompressedKeyMovements.Count - 1].Id,
                client.Character.CellId,
                new List<int>(), true, false);


            client.Send(new GameMapMovementMessage(paths, client.Character.Id));
            client.Send(new BasicNoOperationMessage());
            client.Character.CellId = paths[paths.Length - 1];


            //update
            this._characterRepository.UpdateEntity(client.Character.Id, client.Character);
        }


        /**
         * Send map informations request (actors, interactives, house, fights)
         */
        public async Task SendMapInformationsRequest(GameClient client,
            MapInformationsRequestMessage mapInformationsRequestMessage)
        {
            var map = await this.GetMapById(mapInformationsRequestMessage.mapId);
            if (map == null)
            {
                client.Disconnect();
                return;
            }
            
            var actors = new List<GameRolePlayInformations>();
            
            //characters
            foreach (var character in map.Characters.Values)
            {
                //client character
                actors.Add(new GameRolePlayCharacterInformations(character.Id, character.EntityLook,
                    new EntityDispositionInformations(character.CellId, 3), character.Name,
                    new HumanInformations(), character.AccountId, new ActorAlignmentInformations(0, 0, 0, 3956606)));
            }
            
            //npcs
            foreach (var npc in map.NpcSpawns)
            {
                actors.Add(new GameRolePlayNpcInformations(npc.Id * -1, !npc.OverridedEntityLook.IsEmpty() ? EntityLookHelper.DecodeStringLook(npc.OverridedEntityLook) : EntityLookHelper.DecodeStringLook(npc.Npc.Look),
                    new EntityDispositionInformations(npc.CellId, npc.DirectionId), npc.NpcId, false, 0, npc.Npc));
            }

            //interactive => @TODO do it on Map object in future
            var layers = map.MidgroundLayer
                .Where(x => x.Value.FirstOrDefault(midLayer => midLayer.Id != null) != null)
                .ToList();

            List<InteractiveElement> interactiveElements = new List<InteractiveElement>();
            List<StatedElement> statedElements = new List<StatedElement>();

            foreach (var layer in layers)
            {
                foreach (var cell in layer.Value.Where(x => x.Id != null))
                {
                    if (Map.ZAAP_GFX_ID.Contains(Convert.ToInt32(cell.G)))
                    {
                        interactiveElements.Add(new InteractiveElement((int) cell.Id, 16, new InteractiveElementSkill[]
                        {
                            new InteractiveElementSkill(114, 53040312, 0, "Utiliser", 1, 1, "Base"),
                            new InteractiveElementSkill(44, 53040310, 0, "Sauvegarder", 1, 1, "Base"),
                        }, new InteractiveElementSkill[] { }, "Zaap"));
                    }
                    else
                    {
                        //statedElements
                        statedElements.Add(new StatedElement((int) cell.Id, Convert.ToInt32(layer.Key), 0));

                        interactiveElements.Add(new InteractiveElement((int) cell.Id, 38, new InteractiveElementSkill[]
                        {
                            new InteractiveElementSkill(45, 53040310, 4, "Faucher", 1, 1, "Faucher"),
                        }, new InteractiveElementSkill[] { }, "Blé"));
                    }
                }
            }
            
            client.Send(new MapComplementaryInformationsDataMessage(778, map.Id, new int[] { }, actors.ToArray(),
                interactiveElements.ToArray(), statedElements.ToArray(), new int[] { }, new int[] { }));
        }

        /**
         * Change map movement
         */
        public async Task ChangeMap(GameClient client, ChangeMapMessage changeMapMessage)
        {
            var map = await this.GetMapById(client.Character.MapId);
            Map mapDestination = null;


            if (map == null)
            {
                client.Disconnect();
                return;
            }

            var cellChangeMap = map.CellChangeMaps.FirstOrDefault(x =>
                x.cellId == client.Character.CellId && x.orientation != OrientationEnum.NONE);
            if (cellChangeMap == null)
                return;

            //find map destination from orientation
            switch ((OrientationEnum) cellChangeMap.orientation)
            {
                case OrientationEnum.TOP:
                    mapDestination = this.GetMapById(map.TopNeighbourId).Result;
                    break;
                case OrientationEnum.LEFT:
                    mapDestination = this.GetMapById(map.LeftNeighbourId).Result;
                    break;
                case OrientationEnum.RIGHT:
                    mapDestination = this.GetMapById(map.RightNeighbourId).Result;
                    break;
                case OrientationEnum.BOTTOM:
                    mapDestination = this.GetMapById(map.BottomNeighbourId).Result;
                    break;
            }

            if (mapDestination == null)
            {
                client.Disconnect();
                return;
            }

            client.Character.MapId = mapDestination.Id;
            client.Character.CellId =
                this._pathfinderManager.GetOppositeCellId(mapDestination, client.Character.CellId);
            client.Send(new CurrentMapMessage(client.Character.MapId, "649ae451ca33ec53bbcbcc33becf15f4"));

            map.Characters.Remove(client.Character.Id, out Character removedCharacter);
            mapDestination.Characters.TryAdd(client.Character.Id, client.Character);

            //update
            this._characterRepository.UpdateEntity(client.Character.Id, client.Character);
        }


        /**
         * Get map data by Id (lazy loading method for low mem usage)
         */
        public async Task<Map> GetMapById(long id)
        {
            this.MapsData.TryGetValue(id, out Map map);

            if (map == null)
            {
                if (File.Exists($"/data/maps/{id}.json"))
                {
                    this._logger.Error($"Map with id {id} not found at \"data/maps/{id}.json\"");
                    return null;
                }

                StreamReader reader = new StreamReader($"data/maps/{id}.json");

                try
                {
                    var mapData = await reader.ReadToEndAsync();
                    map = JsonConvert.DeserializeObject<Map>(mapData);

                    if (map != null)
                    {
                        //retrieve npcs
                        map.NpcSpawns = this._npcManager.GetNpcSpawnsByMapId(map.Id);

                        this.MapsData.TryAdd(id, map);
                    }
                }
                catch (Exception ex)
                {
                    this._logger.Error(ex.Message);
                }

                reader.Dispose();
            }

            return map;
        }
    }
}