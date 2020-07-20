using Newtonsoft.Json;

namespace Bolgrot.Core.Common.Entity.Data
{
    public class MountBehaviors
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nameId")]
        public string NameId { get; set; }

        [JsonProperty("descriptionId")]
        public string DescriptionId { get; set; }
    }
}