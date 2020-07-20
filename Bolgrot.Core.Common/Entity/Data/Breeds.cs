using Newtonsoft.Json;

namespace Bolgrot.Core.Common.Entity.Data
{
    public class Breeds
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("shortNameId")]
        public string ShortNameId { get; set; }

        [JsonProperty("longNameId")]
        public string LongNameId { get; set; }

        [JsonProperty("descriptionId")]
        public string DescriptionId { get; set; }

        [JsonProperty("gameplayDescriptionId")]
        public string GameplayDescriptionId { get; set; }

        [JsonProperty("maleLook")]
        public string MaleLook { get; set; }

        [JsonProperty("femaleLook")]
        public string FemaleLook { get; set; }

        [JsonProperty("creatureBonesId")]
        public long CreatureBonesId { get; set; }

        [JsonProperty("maleArtwork")]
        public long MaleArtwork { get; set; }

        [JsonProperty("femaleArtwork")]
        public long FemaleArtwork { get; set; }

        [JsonProperty("statsPointsForStrength")]
        public long[][] StatsPointsForStrength { get; set; }

        [JsonProperty("statsPointsForIntelligence")]
        public long[][] StatsPointsForIntelligence { get; set; }

        [JsonProperty("statsPointsForChance")]
        public long[][] StatsPointsForChance { get; set; }

        [JsonProperty("statsPointsForAgility")]
        public long[][] StatsPointsForAgility { get; set; }

        [JsonProperty("statsPointsForVitality")]
        public long[][] StatsPointsForVitality { get; set; }

        [JsonProperty("statsPointsForWisdom")]
        public long[][] StatsPointsForWisdom { get; set; }

        [JsonProperty("breedSpellsId")]
        public long[] BreedSpellsId { get; set; }

        [JsonProperty("maleColors")]
        public long[] MaleColors { get; set; }

        [JsonProperty("femaleColors")]
        public long[] FemaleColors { get; set; }
    }
}