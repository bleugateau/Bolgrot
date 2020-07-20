using Newtonsoft.Json;

namespace Bolgrot.Server.Auth.Proxy.Requests
{
    public class MapDataRequest
    {
        [JsonProperty("class")]
        public string @class { get; set; }
        
        public int[] ids { get; set; }
    }
}