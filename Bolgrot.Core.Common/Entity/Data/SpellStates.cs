using Newtonsoft.Json;

namespace Bolgrot.Core.Common.Entity.Data
{
    public class SpellStates
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nameId")]
        public string NameId { get; set; }

        [JsonProperty("preventsSpellCast")]
        public bool PreventsSpellCast { get; set; }

        [JsonProperty("preventsFight")]
        public bool PreventsFight { get; set; }

        [JsonProperty("critical")]
        public bool Critical { get; set; }
    }
}