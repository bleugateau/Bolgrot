using Newtonsoft.Json;

namespace Bolgrot.Core.Common.Entity.Data
{
    public class Effects
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("descriptionId")]
        public string DescriptionId { get; set; }

        [JsonProperty("iconId")]
        public long IconId { get; set; }

        [JsonProperty("characteristic")]
        public long Characteristic { get; set; }

        [JsonProperty("category")]
        public long Category { get; set; }

        [JsonProperty("operator")]
        public string Operator { get; set; }

        [JsonProperty("showInTooltip")]
        public bool ShowInTooltip { get; set; }

        [JsonProperty("useDice")]
        public bool UseDice { get; set; }

        [JsonProperty("forceMinMax")]
        public bool ForceMinMax { get; set; }

        [JsonProperty("boost")]
        public bool Boost { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("showInSet")]
        public bool ShowInSet { get; set; }

        [JsonProperty("bonusType")]
        public long BonusType { get; set; }

        [JsonProperty("useInFight")]
        public bool UseInFight { get; set; }

        [JsonProperty("effectPriority")]
        public long EffectPriority { get; set; }
    }
}