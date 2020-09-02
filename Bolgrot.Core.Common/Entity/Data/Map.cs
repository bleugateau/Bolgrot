using System.Collections.Concurrent;
using System.Collections.Generic;
using Bolgrot.Core.Common.Managers.Pathfinding;
using Newtonsoft.Json;

namespace Bolgrot.Core.Common.Entity.Data
{
    public partial class Map
    {
        [JsonProperty("id")] 
        public long Id { get; set; }

        [JsonProperty("topNeighbourId")] 
        public long TopNeighbourId { get; set; }

        [JsonProperty("bottomNeighbourId")] 
        public long BottomNeighbourId { get; set; }

        [JsonProperty("leftNeighbourId")] 
        public long LeftNeighbourId { get; set; }

        [JsonProperty("rightNeighbourId")] 
        public long RightNeighbourId { get; set; }

        [JsonProperty("shadowBonusOnEntities")]
        public long ShadowBonusOnEntities { get; set; }

        [JsonProperty("cells")] 
        public Cell[] Cells { get; set; }

        [JsonProperty("midgroundLayer")] 
        public Dictionary<string, MidgroundLayer[]> MidgroundLayer { get; set; }

        [JsonProperty("atlasLayout")] 
        public AtlasLayout AtlasLayout { get; set; }
        
        [JsonIgnore]
        public List<CellChangeMap> CellChangeMaps = new List<CellChangeMap>();
        
        [JsonIgnore]
        public ConcurrentDictionary<int, Character> Characters = new ConcurrentDictionary<int, Character>();
    }

    public partial class AtlasLayout
    {
        [JsonProperty("width")] 
        public long Width { get; set; }

        [JsonProperty("height")] 
        public long Height { get; set; }

        [JsonProperty("graphicsPositions")] 
        public Dictionary<string, GraphicsPosition> GraphicsPositions { get; set; }
    }

    public partial class GraphicsPosition
    {
        [JsonProperty("sx")] 
        public long Sx { get; set; }

        [JsonProperty("sy")] 
        public long Sy { get; set; }

        [JsonProperty("sw")] 
        public long Sw { get; set; }

        [JsonProperty("sh")] 
        public long Sh { get; set; }

        [JsonProperty("cx", NullValueHandling = NullValueHandling.Ignore)]
        public long? Cx { get; set; }

        [JsonProperty("cy", NullValueHandling = NullValueHandling.Ignore)]
        public long? Cy { get; set; }

        [JsonProperty("cw", NullValueHandling = NullValueHandling.Ignore)]
        public long? Cw { get; set; }

        [JsonProperty("ch", NullValueHandling = NullValueHandling.Ignore)]
        public long? Ch { get; set; }
    }

    public partial class Cell
    {
        [JsonProperty("id")] 
        public int Id { get; set; }

        [JsonProperty("l", NullValueHandling = NullValueHandling.Ignore)]
        public int L { get; set; }

        [JsonProperty("f", NullValueHandling = NullValueHandling.Ignore)]
        public int F { get; set; }
        
        [JsonProperty("c", NullValueHandling = NullValueHandling.Ignore)]
        public int C { get; set; }
        
        [JsonProperty("z", NullValueHandling = NullValueHandling.Ignore)]
        public int Z { get; set; }
        
        [JsonProperty("s", NullValueHandling = NullValueHandling.Ignore)]
        public int S { get; set; }
        
        public bool IsWalkable(bool isFightMode = false)
        {
            var mask = isFightMode ? 5 : 1;
            return (this.L & mask) == 1;
        }
    }

    public partial class MidgroundLayer
    {
        [JsonProperty("g", NullValueHandling = NullValueHandling.Ignore)]
        public long? G { get; set; }

        [JsonProperty("x")] public long X { get; set; }

        [JsonProperty("y")] public double Y { get; set; }

        [JsonProperty("hue")] public long[] Hue { get; set; }

        [JsonProperty("cw", NullValueHandling = NullValueHandling.Ignore)]
        public long? Cw { get; set; }

        [JsonProperty("ch", NullValueHandling = NullValueHandling.Ignore)]
        public long? Ch { get; set; }

        [JsonProperty("sx", NullValueHandling = NullValueHandling.Ignore)]
        public long? Sx { get; set; }

        [JsonProperty("cx", NullValueHandling = NullValueHandling.Ignore)]
        public long? Cx { get; set; }

        [JsonProperty("cy", NullValueHandling = NullValueHandling.Ignore)]
        public long? Cy { get; set; }

        [JsonProperty("look", NullValueHandling = NullValueHandling.Ignore)]
        public long? Look { get; set; }

        [JsonProperty("dmin", NullValueHandling = NullValueHandling.Ignore)]
        public long? Dmin { get; set; }

        [JsonProperty("dmax", NullValueHandling = NullValueHandling.Ignore)]
        public long? Dmax { get; set; }

        [JsonProperty("anim", NullValueHandling = NullValueHandling.Ignore)]
        public long? Anim { get; set; }

        [JsonProperty("astc", NullValueHandling = NullValueHandling.Ignore)]
        public long? Astc { get; set; }
    }
    
    
}