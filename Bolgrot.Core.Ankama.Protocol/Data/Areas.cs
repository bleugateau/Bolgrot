using Newtonsoft.Json;

namespace Bolgrot.Core.Ankama.Protocol.Data
{
    public class Areas
    {
        [JsonProperty("_type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nameId")]
        public string NameId { get; set; }

        [JsonProperty("superAreaId")]
        public long SuperAreaId { get; set; }

        [JsonProperty("containHouses")]
        public bool ContainHouses { get; set; }

        [JsonProperty("containPaddocks")]
        public bool ContainPaddocks { get; set; }

        [JsonProperty("bounds")]
        public Bounds Bounds { get; set; }
    }

    public class Bounds
    {
        [JsonProperty("_type")]
        public string Type { get; set; }

        [JsonProperty("x")]
        public long X { get; set; }

        [JsonProperty("y")]
        public long Y { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }
}