using Newtonsoft.Json;

namespace Bolgrot.Server.Auth.Proxy.Response
{
    public class CreateTokenResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}