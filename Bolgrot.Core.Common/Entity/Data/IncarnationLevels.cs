using Newtonsoft.Json;

namespace Bolgrot.Core.Common.Entity.Data
{
    public class IncarnationLevels
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("incarnationId")]
        public long IncarnationId { get; set; }

        [JsonProperty("level")]
        public long Level { get; set; }

        [JsonProperty("requiredXp")]
        public long RequiredXp { get; set; }
    }
}