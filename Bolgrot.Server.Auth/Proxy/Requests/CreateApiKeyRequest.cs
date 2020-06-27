using Newtonsoft.Json;

namespace Bolgrot.Server.Auth.Proxy.Requests
{
    public class CreateApiKeyRequest
    {
        public string login { get; set; }
        
        public string password { get; set; }
        
        public bool long_life_token { get; set; }
    } 
}