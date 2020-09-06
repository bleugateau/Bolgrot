using Newtonsoft.Json;

namespace Bolgrot.Core.Ankama.Protocol.Data
{
    public class ServerCommunities
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nameId")]
        public string NameId { get; set; }

        [JsonProperty("defaultCountries")]
        public string[] DefaultCountries { get; set; }

        [JsonProperty("shortId")]
        public string ShortId { get; set; }
    }
}