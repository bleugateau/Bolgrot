using ServiceStack.DataAnnotations;

namespace Bolgrot.Core.Common.Entity
{
    public abstract class AbstractEntity
    {
        [AutoIncrement]
        public int Id { get; set; }
        
        [Ignore]
        public bool IsNew { get; set; }
        
        [Ignore]
        public bool IsDeleted { get; set; }
        
        [Ignore]
        public bool IsEdited { get; set; }
    }
}