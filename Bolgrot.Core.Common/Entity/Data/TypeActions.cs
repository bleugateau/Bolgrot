using Newtonsoft.Json;

namespace Bolgrot.Core.Common.Entity.Data
{
    public class TypeActions
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("elementName")]
        public string ElementName { get; set; }

        [JsonProperty("elementId")]
        public long ElementId { get; set; }
    }
}