using DataKeeper.Framework.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Ums.User.Entities
{
    [Table("Account")]
    class AccountEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
