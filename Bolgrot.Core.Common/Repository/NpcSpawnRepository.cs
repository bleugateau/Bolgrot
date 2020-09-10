using System.Collections.Generic;
using System.Data;
using System.Linq;
using Bolgrot.Core.Common.Entity;

namespace Bolgrot.Core.Common.Repository
{
    public interface INpcSpawnRepository
    {
        public List<NpcSpawn> GetNpcsFromMapId(long mapId);
    }
    
    public class NpcSpawnRepository: Repository<NpcSpawn>, INpcSpawnRepository
    {
        public NpcSpawnRepository(IDbConnection databaseManager) : base(databaseManager)
        {
        }

        public List<NpcSpawn> GetNpcsFromMapId(long mapId)
        {
            return this.Entities().Values.Where(x => x.MapId == mapId).ToList();
        }
    }
}