using Newtonsoft.Json;

namespace Bolgrot.Core.Common.Entity.Data
{
    public class SuperAreas
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nameId")]
        public string NameId { get; set; }

        [JsonProperty("worldmapId")]
        public long WorldmapId { get; set; }
    }
}