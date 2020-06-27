using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bolgrot.Core.Common.Entities
{
    [Table("accounts")]
    public class Account
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string ApiKey { get; set; }
        
        public string Ip { get; set; }
        public DateTime ApiKeyExpirationDate { get; set; }
    }
}