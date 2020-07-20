using Newtonsoft.Json;

namespace Bolgrot.Core.Common.Entity.Data
{
    public class AlignmentGift
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nameId")]
        public string NameId { get; set; }

        [JsonProperty("effectId")]
        public long EffectId { get; set; }

        [JsonProperty("gfxId")]
        public long GfxId { get; set; }
    }
}