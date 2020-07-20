using Newtonsoft.Json;

namespace Bolgrot.Core.Common.Entity.Data
{
    public class RankNames
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nameId")]
        public string NameId { get; set; }

        [JsonProperty("order")]
        public long Order { get; set; }
    }
}