using System;
using System.Threading.Tasks;
using Bolgrot.Core.Common.Repository;
using Bolgrot.Server.Auth.Proxy.Enums;
using Bolgrot.Server.Auth.Proxy.Requests;
using Bolgrot.Server.Auth.Proxy.Response;
using Newtonsoft.Json;

namespace Bolgrot.Server.Auth.Managers
{

    public interface ITicketManager
    {
        Task<string> GetTicket(string ticket);
    }

    public class TicketManager : ITicketManager
    {
        private IAccountRepository _accountRepository = null;
        private readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public TicketManager(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }



        /**
         * Get Ticket on WebSocket
         */
        public async Task<string> GetTicket(string ticket)
        {
            var createApiFailedResponse = new CreateApiResponseFailed();
            var account = await this._accountRepository.GetAccountByTicket(ticket);
            
            if (account == null)
            {
                createApiFailedResponse.Reason = Enum.GetName(typeof(CreateApiFailedEnum), CreateApiFailedEnum.FAILED);
                return JsonConvert.SerializeObject(createApiFailedResponse);
            }
            return JsonConvert.SerializeObject(account);

        }
    }
}

