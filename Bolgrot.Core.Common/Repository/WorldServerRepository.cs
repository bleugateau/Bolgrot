using System.Collections.Generic;
using System.Data;
using System.Linq;
using Bolgrot.Core.Common.Entity;

namespace Bolgrot.Core.Common.Repository
{
    public interface IWorldServerRepository: IRepository<WorldServer>
    {
    }
    
    public class WorldServerRepository : Repository<WorldServer>, IWorldServerRepository
    {
        public WorldServerRepository(IDbConnection databaseManager) : base(databaseManager)
        {
        }

    }
}