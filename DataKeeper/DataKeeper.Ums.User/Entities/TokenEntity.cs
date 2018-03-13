using DataKeeper.Framework.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Ums.User.Entities
{
    [Table("Token")]
    class TokenEntity : BaseEntity
    {
        public TokenEntity()
        {
            LastUsed = DateTime.Now;
        }

        public Guid UserId { get; set; }
        public Guid Token { get; set; }
        public bool IsValid { get; set; }
        public DateTime LastUsed { get; set; }
    }
}
