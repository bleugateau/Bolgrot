using System.Data;
using System.Threading.Tasks;
using Bolgrot.Core.Common.Managers.Repository;
using Bolgrot.Core.Common.Repository;

namespace Bolgrot.Server.Game.Managers
{
    public class RepositoryPersistManager : AbstractRepositoryPersistManager
    {
        private ICharacterRepository _characterRepository;
        
        public RepositoryPersistManager(IDbConnection connection, ICharacterRepository characterRepository) : base(connection, 1000)
        {
            this._characterRepository = characterRepository;
        }

        protected override Task PersistCallback()
        {
            
            this._logger.Debug($"Save in progress...");

            this._characterRepository.PersistEntities();
            
            return base.PersistCallback();
        }
    }
}