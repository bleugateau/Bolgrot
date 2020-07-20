using Newtonsoft.Json;

namespace Bolgrot.Core.Common.Entity.Data
{
    public class WorldMaps
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("origineX")]
        public long OrigineX { get; set; }

        [JsonProperty("origineY")]
        public long OrigineY { get; set; }

        [JsonProperty("mapWidth")]
        public long MapWidth { get; set; }

        [JsonProperty("mapHeight")]
        public long MapHeight { get; set; }

        [JsonProperty("horizontalChunck")]
        public long HorizontalChunck { get; set; }

        [JsonProperty("verticalChunck")]
        public long VerticalChunck { get; set; }

        [JsonProperty("viewableEverywhere")]
        public bool ViewableEverywhere { get; set; }

        [JsonProperty("minScale")]
        public double MinScale { get; set; }

        [JsonProperty("maxScale")]
        public long MaxScale { get; set; }

        [JsonProperty("startScale")]
        public double StartScale { get; set; }

        [JsonProperty("centerX")]
        public long CenterX { get; set; }

        [JsonProperty("centerY")]
        public long CenterY { get; set; }

        [JsonProperty("totalWidth")]
        public long TotalWidth { get; set; }

        [JsonProperty("totalHeight")]
        public long TotalHeight { get; set; }

        [JsonProperty("zoom")]
        public string[] Zoom { get; set; }
    }
}