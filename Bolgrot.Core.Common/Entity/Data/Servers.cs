using Newtonsoft.Json;

namespace Bolgrot.Core.Common.Entity.Data
{
    public class Servers
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nameId")]
        public string NameId { get; set; }

        [JsonProperty("commentId")]
        public string CommentId { get; set; }

        [JsonProperty("openingDate")]
        public long OpeningDate { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("populationId")]
        public long PopulationId { get; set; }

        [JsonProperty("gameTypeId")]
        public long GameTypeId { get; set; }

        [JsonProperty("communityId")]
        public long CommunityId { get; set; }

        [JsonProperty("restrictedToLanguages")]
        public string[] RestrictedToLanguages { get; set; }
    }
}