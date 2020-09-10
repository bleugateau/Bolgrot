using System.Text.Json.Serialization;
using Bolgrot.Core.Ankama.Protocol.Data;
using ServiceStack.DataAnnotations;

namespace Bolgrot.Core.Common.Entity
{
    public class NpcSpawn : AbstractEntity
    {
        [PrimaryKey, AutoIncrement]
        public override int Id { get; set; }
        
        public int NpcId { get; set; }
        public long MapId { get; set; }
        
        [StringLength(StringLengthAttribute.MaxText)]
        public string OverridedEntityLook { get; set; }
        
        public int CellId { get; set; }
        
        public int DirectionId { get; set; }
        
        [Ignore]
        public Npcs Npc { get; set; }
    }
}