using Newtonsoft.Json;

namespace Bolgrot.Core.Common.Entity.Data
{
    public class Spells
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nameId")]
        public string NameId { get; set; }

        [JsonProperty("descriptionId")]
        public string DescriptionId { get; set; }

        [JsonProperty("typeId")]
        public long TypeId { get; set; }

        [JsonProperty("scriptParams")]
        public string ScriptParams { get; set; }

        [JsonProperty("scriptParamsCritical")]
        public string ScriptParamsCritical { get; set; }

        [JsonProperty("scriptId")]
        public long ScriptId { get; set; }

        [JsonProperty("scriptIdCritical")]
        public long ScriptIdCritical { get; set; }

        [JsonProperty("iconId")]
        public long IconId { get; set; }

        [JsonProperty("spellLevels")]
        public long[] SpellLevels { get; set; }
    }
}