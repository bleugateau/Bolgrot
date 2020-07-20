using Newtonsoft.Json;

namespace Bolgrot.Core.Common.Entity.Data
{
    public class SpellTypes
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("longNameId")]
        public string LongNameId { get; set; }

        [JsonProperty("shortNameId")]
        public string ShortNameId { get; set; }
    }
}