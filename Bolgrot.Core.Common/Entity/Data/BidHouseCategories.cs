using Newtonsoft.Json;

namespace Bolgrot.Core.Common.Entity.Data
{
    public class BidHouseCategories
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("allowedTypes")]
        public long[] AllowedTypes { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}