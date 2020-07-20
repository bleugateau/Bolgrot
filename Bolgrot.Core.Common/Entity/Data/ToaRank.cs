using Newtonsoft.Json;

namespace Bolgrot.Core.Common.Entity.Data
{
    public class ToaRank
    {
        [JsonProperty("_type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nameId")]
        public string NameId { get; set; }

        [JsonProperty("minScore")]
        public long MinScore { get; set; }

        [JsonProperty("minFixedPosition")]
        public long MinFixedPosition { get; set; }

        [JsonProperty("goultines")]
        public long Goultines { get; set; }

        [JsonProperty("rewards")]
        public Reward[] Rewards { get; set; }
    }
    
    public class Reward
    {
        [JsonProperty("_type")]
        public string Type { get; set; }

        [JsonProperty("itemId")]
        public long ItemId { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }
    }
}