using Newtonsoft.Json;

namespace Bolgrot.Core.Common.Entity.Data
{
    public class CensoredWords
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("listId")]
        public long ListId { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("word")]
        public string Word { get; set; }

        [JsonProperty("deepLooking")]
        public bool DeepLooking { get; set; }
    }
}