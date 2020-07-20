using Newtonsoft.Json;

namespace Bolgrot.Core.Common.Entity.Data
{
    public class AlmanaxCalendars
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nameId")]
        public string NameId { get; set; }

        [JsonProperty("descId")]
        public string DescId { get; set; }

        [JsonProperty("npcId")]
        public long NpcId { get; set; }
    }
}