using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Bolgrot.Core.Common.Entities;
using Bolgrot.Server.Auth.Proxy.Enums;
using Bolgrot.Server.Auth.Proxy.Requests;
using Bolgrot.Server.Auth.Proxy.Response;
using Dapper;
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
        private IDbConnection _databaseManager = null;

        public HaapiManager(IDbConnection databaseManager)
        {
            _databaseManager = databaseManager;
        }

        /**
         * Create Key from CreateApiKeyRequest
         */
        public async Task<string> CreateKey(CreateApiKeyRequest createApiKeyRequest, string ipAddress)
        {
            var createApiResponse = new CreateApiResponse();
            var createApiFailedResponse = new CreateApiResponseFailed();

            var account = this._databaseManager.QueryAsync<Account>("SELECT * FROM account WHERE login = @login", new
                {
                    login = createApiKeyRequest.login
                }).Result
                .FirstOrDefault();

            //return failed if account is wrong
            if (account == null || account.Password != createApiKeyRequest.password)
            {
                createApiFailedResponse.Reason = Enum.GetName(typeof(CreateApiFailedEnum), CreateApiFailedEnum.FAILED);
                return JsonConvert.SerializeObject(createApiFailedResponse);
            }

            account.ApiKey = Guid.NewGuid().ToString();
            account.ApiKeyExpirationDate = DateTime.Now.AddHours(4);
            account.Ip = ipAddress;

            //update account
            await this._databaseManager.ExecuteAsync(
                "UPDATE account SET apikey = @ApiKey, ip = @Ip, apikey_expiration_date = @ApiKeyExpirationDate WHERE login = @Login",
                account);

            createApiResponse.AccountId = account.Id;
            createApiResponse.AddedDate = DateTimeOffset.Now;
            createApiResponse.Data = new CreateApiResponseData()
            {
                Country = "FR",
                Currency = "EUR"
            };
            createApiResponse.Key = account.ApiKey;
            createApiResponse.ExpirationDate = account.ApiKeyExpirationDate;
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
            
            var account = this._databaseManager.QueryAsync<Account>("SELECT * FROM account WHERE apikey = @apikey", new
                {
                    apikey = apiKey
                }).Result
                .FirstOrDefault();
            
            
            if (account == null)
            {
                return "";
            }
            
            account.Token = Guid.NewGuid().ToString();

            await this._databaseManager.ExecuteAsync(
                "UPDATE account SET token = @Token WHERE login = @Login",
                account);

            createTokenResponse.Token = account.Token;
            

            return JsonConvert.SerializeObject(createTokenResponse);
        }
    }
}

