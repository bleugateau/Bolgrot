using Newtonsoft.Json;

namespace Bolgrot.Core.Ankama.Protocol.Data
{
    public class AlignmentTitles
    {
        [JsonProperty("sideId")]
        public long SideId { get; set; }

        [JsonProperty("namesId")]
        public string[] NamesId { get; set; }

        [JsonProperty("shortsId")]
        public string[] ShortsId { get; set; }
    }
}