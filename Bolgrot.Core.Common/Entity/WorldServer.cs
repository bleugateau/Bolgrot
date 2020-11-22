using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using ServiceStack.DataAnnotations;

namespace Bolgrot.Core.Common.Entity
{
    public class WorldServer : AbstractEntity
    {
        [PrimaryKey, AutoIncrement]
        public override int Id { get; set; }
        
        public string Name { get; set; }

        public short Port { get; set; }
        
        public string Address { get; set; }
        public string Access { get; set; }

        public bool RequireSubscription { get; set; }
        
        public int Completion { get; set; }
        
        public bool ServerSelectable { get; set; }
        
        public int CharCapacity { get; set; }

        [NotNull, AutoIncrement]
        public int CharsCount { get; set; }
        public int Status { get; set; }
        [Default("CURRENT_TIMESTAMP()")]
        public DateTime CreationDate { get; set; }
        public byte Type { get; set; }

    }
}