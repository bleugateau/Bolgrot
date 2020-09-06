using Newtonsoft.Json;

namespace Bolgrot.Core.Ankama.Protocol.Data
{
    public class AchievementCategories
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nameId")]
        public string NameId { get; set; }

        [JsonProperty("parentId")]
        public long ParentId { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("order")]
        public long Order { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("achievementIds")]
        public long[] AchievementIds { get; set; }
    }
}