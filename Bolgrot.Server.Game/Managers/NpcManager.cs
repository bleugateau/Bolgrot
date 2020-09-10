using System.Collections.Generic;
using System.Linq;
using Bolgrot.Core.Ankama.Protocol.Data;
using Bolgrot.Core.Common.Entity;
using Bolgrot.Core.Common.Repository;

namespace Bolgrot.Server.Game.Managers
{
    public interface INpcManager
    {
        public List<NpcSpawn> GetNpcSpawnsByMapId(long mapId);
    }

    public class NpcManager : AbstractGameManager, INpcManager
    {
        public Dictionary<int, Npcs> NpcsData { get; }

        private INpcSpawnRepository _npcSpawnRepository;


        public NpcManager(INpcSpawnRepository npcSpawnRepository)
        {
            this._logger.Info("NpcManager loading...");

            this._npcSpawnRepository = npcSpawnRepository;

            this.NpcsData = this.LoadGameData<Npcs>();
        }


        /**
         * Get npc on map id
         */
        public List<NpcSpawn> GetNpcSpawnsByMapId(long mapId)
        {
            List<NpcSpawn> npcSpawns = new List<NpcSpawn>();
            foreach (var npcSpawn in this._npcSpawnRepository.GetNpcsFromMapId(mapId))
            {
                this.NpcsData.TryGetValue(npcSpawn.NpcId, out Npcs npcData);

                if (npcData == null)
                    continue;

                //fill data
                npcSpawn.Npc = npcData;
                npcSpawns.Add(npcSpawn);
            }

            return npcSpawns;
        }
    }
}