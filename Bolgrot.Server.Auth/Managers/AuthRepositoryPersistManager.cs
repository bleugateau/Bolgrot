using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Bolgrot.Core.Common.Entity;
using Bolgrot.Core.Common.Managers.Repository;
using Bolgrot.Core.Common.Repository;
using ServiceStack.OrmLite;

namespace Bolgrot.Server.Auth.Managers
{
    public class AuthRepositoryPersistManager : AbstractRepositoryPersistManager
    {
        private IAccountRepository _accountRepository;
        public AuthRepositoryPersistManager(IDbConnection connection, IAccountRepository accountRepository) : base(connection, 10000)
        {
            this._accountRepository = accountRepository;
        }

        protected override Task PersistCallback()
        {
            
            this._dbConnection.Open();
            
            this._logger.Debug($"Save in progress...");
            
            this.PersistEntities<Account>(this._accountRepository.Entities());
            this._logger.Debug($"Save account...");
            
            this._dbConnection.Close();
            
            return base.PersistCallback();
        }
    }
}