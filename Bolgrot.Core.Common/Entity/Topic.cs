using Newtonsoft.Json;
using ServiceStack.DataAnnotations;

namespace Bolgrot.Core.Common.Entities
{
    public class Topic
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("pinned")]
        public bool Pinned { get; set; }

        [JsonProperty("added_date")]
        public string AddedDate { get; set; }
    }
}