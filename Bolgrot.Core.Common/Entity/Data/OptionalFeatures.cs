using Newtonsoft.Json;

namespace Bolgrot.Core.Common.Entity.Data
{
    public class OptionalFeatures
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("keyword")]
        public string Keyword { get; set; }
    }
}