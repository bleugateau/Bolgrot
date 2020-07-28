using System;
using System.Threading.Tasks;
using Bolgrot.Core.Common.Repository;
using Bolgrot.Server.Auth.Proxy.Enums;
using Bolgrot.Server.Auth.Proxy.Requests;
using Bolgrot.Server.Auth.Proxy.Response;
using Newtonsoft.Json;

namespace Bolgrot.Server.Auth.Managers
{

    public interface IHaapiManager
    {
        Task<string> CreateKey(CreateApiKeyRequest createApiKeyRequest, string ipAddress);
        Task<string> BuildToken(string apiKey);
    }

    public class HaapiManager : IHaapiManager
    {
        private IAccountRepository _accountRepository = null;
        private readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public HaapiManager(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        /**
         * Create Key from CreateApiKeyRequest
         */
        public async Task<string> CreateKey(CreateApiKeyRequest createApiKeyRequest, string ipAddress)
        {
            var createApiResponse = new CreateApiResponse();
            var createApiFailedResponse = new CreateApiResponseFailed();

            var account = await this._accountRepository.GetAccountByLogin(createApiKeyRequest.login);

            //return failed if account is wrong
            if (account == null || account.Password != createApiKeyRequest.password)
            {
                createApiFailedResponse.Reason = Enum.GetName(typeof(CreateApiFailedEnum), CreateApiFailedEnum.FAILED);
                return JsonConvert.SerializeObject(createApiFailedResponse);
            }

            this._accountRepository.Entities().AddOrUpdate(account.Id, account, (i, editedAccount) =>
            {
                editedAccount.ApiKey = Guid.NewGuid().ToString();
                editedAccount.ApiKeyExpirationDate = DateTime.Now.AddHours(4);
                editedAccount.Ip = ipAddress;
                editedAccount.IsEdited = true;
                
                return editedAccount;
            });
            

            createApiResponse.AccountId = account.Id;
            createApiResponse.AddedDate = DateTimeOffset.Now;
            createApiResponse.Data = new CreateApiResponseData()
            {
                Country = "FR",
                Currency = "EUR"
            };
            createApiResponse.Key = account.ApiKey;
            createApiResponse.ExpirationDate = DateTime.Now.AddHours(4);
            createApiResponse.RefreshToken = "";
            createApiResponse.Ip = account.Ip;

            return JsonConvert.SerializeObject(createApiResponse);
        }

        /**
         * Build token for authentication on WebSocket
         */
        public async Task<string> BuildToken(string apiKey)
        {
            var createTokenResponse = new CreateTokenResponse();
            var account = await this._accountRepository.GetAccountByApiKey(apiKey);
            
            if (account == null || ((DateTime) account.ApiKeyExpirationDate <= DateTime.Now))
            {
                return "";
            }
            
            this._logger.Debug($"Token value before edit {account.Token}");
            
            //edit token and save it
            this._accountRepository.Entities().AddOrUpdate(account.Id, account, (i, editedAccount) =>
            {
                editedAccount.Token = Guid.NewGuid().ToString();
                editedAccount.IsEdited = true;
                return editedAccount;
            });

            createTokenResponse.Token = account.Token;
            
            this._logger.Debug($"Token value after edit {createTokenResponse.Token}");
            

            return JsonConvert.SerializeObject(createTokenResponse);
        }
    }
}

