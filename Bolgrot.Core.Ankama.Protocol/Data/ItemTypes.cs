using Newtonsoft.Json;

namespace Bolgrot.Core.Ankama.Protocol.Data
{
    public class ItemTypes
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nameId")]
        public string NameId { get; set; }

        [JsonProperty("superTypeId")]
        public long SuperTypeId { get; set; }

        [JsonProperty("plural")]
        public bool Plural { get; set; }

        [JsonProperty("gender")]
        public long Gender { get; set; }

        [JsonProperty("rawZone")]
        public string RawZone { get; set; }

        [JsonProperty("needUseConfirm")]
        public bool NeedUseConfirm { get; set; }
    }
}