using Newtonsoft.Json;

namespace Bolgrot.Core.Ankama.Protocol.Data
{
    public class Interactives
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nameId")]
        public string NameId { get; set; }

        [JsonProperty("actionId")]
        public long ActionId { get; set; }

        [JsonProperty("displayTooltip")]
        public bool DisplayTooltip { get; set; }
    }
}