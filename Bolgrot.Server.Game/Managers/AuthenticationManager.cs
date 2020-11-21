using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Bolgrot.Core.Common.Entity;
using Bolgrot.Core.Common.Network;
using Bolgrot.Core.Common.Repository;
using Bolgrot.Server.Game.Network;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using ServiceStack;

namespace Bolgrot.Server.Game.Managers
{
    public interface IAuthenticationManager
    {
        Task<Account> GetAccountByTicket(string ticket);
    }
    public /*abstract*/ class AuthenticationManager : IAuthenticationManager
    {
        private IAccountRepository _accountRepository = null;
        //public AuthenticationManager()
        //{

        //}
        public AuthenticationManager(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public void Initialize()
        {
           
            //todo
        }

        public async Task<Account> GetAccountByTicket(string ticket)
        {
            return await this._accountRepository.GetAccountByTicket(ticket);
            
        }
        


    }
}