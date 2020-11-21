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
        private bool saving;
        public AuthRepositoryPersistManager(IDbConnection connection, IAccountRepository accountRepository) : base(connection, 100000)
        {
            this._accountRepository = accountRepository;
            saving = false;
        }

        protected override Task PersistCallback()
        {
            this._logger.Debug($"Save in progress...");
            if(saving ==false)
            this._accountRepository.PersistEntities();
            else
                this._logger.Debug($"Another Save in progress...");

            return base.PersistCallback();
        }
        public void ForceSave()
        {
            saving = true;
            this._logger.Debug($"Save in progress...");
            this._accountRepository.PersistEntities();
            saving = false;
        }
    }
}