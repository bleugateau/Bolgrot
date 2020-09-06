using Bolgrot.Core.Ankama.Protocol.Types;
using Newtonsoft.Json;

namespace Bolgrot.Core.Ankama.Protocol.Data
{
    public class Npcs
    {
        [JsonProperty("_type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nameId")]
        public string NameId { get; set; }

        [JsonProperty("dialogMessages")]
        public long[][] DialogMessages { get; set; }

        [JsonProperty("dialogReplies")]
        public object[] DialogReplies { get; set; }

        [JsonProperty("actions")]
        public long[] Actions { get; set; }

        [JsonProperty("gender")]
        public long Gender { get; set; }

        [JsonProperty("look")]
        public string Look { get; set; }

        [JsonProperty("animFunList")]
        public object[] AnimFunList { get; set; }
    }
}