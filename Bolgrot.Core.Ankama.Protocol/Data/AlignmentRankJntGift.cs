using Newtonsoft.Json;

namespace Bolgrot.Core.Ankama.Protocol.Data
{
    public class AlignmentRankJntGift
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("gifts")]
        public long[] Gifts { get; set; }

        [JsonProperty("parameters")]
        public long[] Parameters { get; set; }

        [JsonProperty("levels")]
        public long[] Levels { get; set; }
    }
}