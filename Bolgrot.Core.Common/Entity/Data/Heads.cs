using Newtonsoft.Json;

namespace Bolgrot.Core.Common.Entity.Data
{
    public class Heads
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("skins")]
        public long Skins { get; set; }

        [JsonProperty("assetId")]
        public string AssetId { get; set; }

        [JsonProperty("breed")]
        public long Breed { get; set; }

        [JsonProperty("gender")]
        public long Gender { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("order")]
        public long Order { get; set; }
    }
}