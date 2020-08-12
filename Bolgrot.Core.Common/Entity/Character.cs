using Bolgrot.Core.Ankama.Protocol.Types;
using Newtonsoft.Json;
using ServiceStack.DataAnnotations;
using Swan.Formatters;

namespace Bolgrot.Core.Common.Entity
{
    public class Character : AbstractEntity
    {
        [AutoIncrement]
        public override int Id { get; set; }
        
        public int AccountId { get; set; }
        
        public double Experiences { get; set; }

        public string Name { get; set; }
        
        public int Breed { get; set; }
        
        public bool Sex { get; set; }
        
        [StringLength(StringLengthAttribute.MaxText)]
        public string EntityLookData { get; set; }

        [Ignore] public EntityLook EntityLook => JsonConvert.DeserializeObject<EntityLook>(this.EntityLookData);
    }
}