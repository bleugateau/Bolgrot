using Newtonsoft.Json;

namespace Bolgrot.Core.Common.Entity.Data
{
    public class Smileys
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("order")]
        public long Order { get; set; }

        [JsonProperty("gfxId")]
        public string GfxId { get; set; }

        [JsonProperty("forPlayers")]
        public bool ForPlayers { get; set; }

        [JsonProperty("triggers")]
        public object[] Triggers { get; set; }
    }
}