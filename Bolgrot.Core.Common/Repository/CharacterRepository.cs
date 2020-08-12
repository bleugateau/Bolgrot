using System.Data;
using Bolgrot.Core.Common.Entity;

namespace Bolgrot.Core.Common.Repository
{

    public interface ICharacterRepository : IRepository<Character>
    {
        
    }
    
    public class CharacterRepository : Repository<Character>, ICharacterRepository
    {
        public CharacterRepository(IDbConnection databaseManager) : base(databaseManager)
        {
        }
    }
}