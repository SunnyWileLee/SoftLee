using DkmsCore.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dkms.Ums.Account.Repositories
{
    [Table("Token")]
    public class TokenEntity : DkmsUserEntity
    {
        public TokenEntity()
        {
            ExpirationTime = DateTime.Now.AddDays(30);
        }
        [MaxLength(200)]
        public string Token { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
