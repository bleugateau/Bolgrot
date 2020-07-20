using Newtonsoft.Json;

namespace Bolgrot.Core.Common.Entity.Data
{
    public class ChatChannels
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nameId")]
        public string NameId { get; set; }

        [JsonProperty("shortcut")]
        public string Shortcut { get; set; }

        [JsonProperty("shortcutKey")]
        public string ShortcutKey { get; set; }

        [JsonProperty("isPrivate")]
        public bool IsPrivate { get; set; }

        [JsonProperty("allowObjects")]
        public bool AllowObjects { get; set; }
    }
}