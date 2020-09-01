using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Bolgrot.Core.Ankama.Protocol.Messages;
using Bolgrot.Core.Ankama.Protocol.SendMessages;
using Bolgrot.Core.Common.Entity.Data;
using Bolgrot.Core.Common.Managers.Pathfinding;
using Bolgrot.Core.Common.Repository;
using Bolgrot.Server.Game.Network;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bolgrot.Server.Game.Managers
{
    public interface IMapManager
    {
        public Task<Map> GetMapById(long id);

        public Task GameMapMovement(GameClient client,
            GameMapMovementRequestMessage gameMapMovementRequestMessage);
    }

    public class MapManager : AbstractGameManager, IMapManager
    {
        public ConcurrentDictionary<long, Map> MapsData { get; set; }

        private IPathfinderManager _pathfinderManager;
        private ICharacterRepository _characterRepository;

        public MapManager(IPathfinderManager pathfinderManager, ICharacterRepository characterRepository)
        {
            this._logger.Info("MapManager loading...");

            this.MapsData = new ConcurrentDictionary<long, Map>();
            this._pathfinderManager = pathfinderManager;
            this._characterRepository = characterRepository;
        }

        /**
         * Manage game map movement request
         */
        public async Task GameMapMovement(GameClient client, GameMapMovementRequestMessage gameMapMovementRequestMessage)
        {
            var map = await this.GetMapById(client.Character.MapId);
            if (map == null)
            {
                client.Send(new GameMapNoMovementMessage());
                return;
            }

            var decompressedKeyMovements =
                this._pathfinderManager.DecompressKeyMovements(map, gameMapMovementRequestMessage.keyMovements);

            if ((gameMapMovementRequestMessage.keyMovements.Length - 1) <= 0 || decompressedKeyMovements.Find(x => !x.IsWalkable()) != null)
            {
                client.Send(new GameMapNoMovementMessage());
                return;
            }
            
            var paths = await this._pathfinderManager.GetPath(map, decompressedKeyMovements[decompressedKeyMovements.Count - 1].Id,
                client.Character.CellId,
                new List<int>(), true, false);
            
            
            client.Send(new GameMapMovementMessage(paths, client.Character.Id));
            client.Send(new BasicNoOperationMessage());
            client.Character.CellId = paths[paths.Length - 1];
            
            
            this._characterRepository.Entities().AddOrUpdate(client.Character.Id, client.Character, (i, editedCharacter) =>
            {
                editedCharacter.CellId = client.Character.CellId;
                editedCharacter.IsEdited = true;
                return editedCharacter;
            });
            
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