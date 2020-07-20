using Newtonsoft.Json;

namespace Bolgrot.Core.Common.Entity.Data
{
    public class ServerPopulations
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nameId")]
        public string NameId { get; set; }

        [JsonProperty("weight")]
        public long Weight { get; set; }
    }
}