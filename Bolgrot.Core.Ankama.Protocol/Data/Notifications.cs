using Newtonsoft.Json;

namespace Bolgrot.Core.Ankama.Protocol.Data
{
    public class Notifications
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("titleId")]
        public string TitleId { get; set; }

        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        [JsonProperty("iconId")]
        public long IconId { get; set; }

        [JsonProperty("typeId")]
        public long TypeId { get; set; }

        [JsonProperty("trigger")]
        public string Trigger { get; set; }
    }
}