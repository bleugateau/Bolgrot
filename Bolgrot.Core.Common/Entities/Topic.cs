using Newtonsoft.Json;

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


        public Topic(long id, string title, string content, bool pinned, string addedDate)
        {
            Id = id;
            Title = title;
            Content = content;
            Pinned = pinned;
            AddedDate = addedDate;
        }
    }
}