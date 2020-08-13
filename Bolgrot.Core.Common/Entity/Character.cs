using System.ComponentModel.DataAnnotations.Schema;
using Bolgrot.Core.Ankama.Protocol.Types;
using Newtonsoft.Json;
using ServiceStack.DataAnnotations;

namespace Bolgrot.Core.Common.Entity
{
    public class Character : AbstractEntity
    {
        [PrimaryKey, AutoIncrement]
        public override int Id { get; set; }
        
        public int AccountId { get; set; }
        
        [Default(1)]
        public int Level { get; set; }
        
        [Default(0)]
        public double Experiences { get; set; }

        public string Name { get; set; }
        
        public int Breed { get; set; }
        
        public bool Sex { get; set; }
        
        [StringLength(StringLengthAttribute.MaxText)]
        public string EntityLookData { get; set; }

        [Ignore] public EntityLook EntityLook => JsonConvert.DeserializeObject<EntityLook>(this.EntityLookData);
    }
}