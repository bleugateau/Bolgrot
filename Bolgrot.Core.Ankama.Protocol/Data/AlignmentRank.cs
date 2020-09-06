using Newtonsoft.Json;

namespace Bolgrot.Core.Ankama.Protocol.Data
{
    public class AlignmentRank
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("orderId")]
        public long OrderId { get; set; }

        [JsonProperty("nameId")]
        public string NameId { get; set; }

        [JsonProperty("descriptionId")]
        public string DescriptionId { get; set; }

        [JsonProperty("minimumAlignment")]
        public long MinimumAlignment { get; set; }

        [JsonProperty("objectsStolen")]
        public long ObjectsStolen { get; set; }

        [JsonProperty("gifts")]
        public object[] Gifts { get; set; }
    }
}