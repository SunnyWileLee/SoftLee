using DkmsCore.Persistence;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dkms.Ums.Account.Repositories
{
    [Table("Account")]
    public class AccountEntity : DkmsEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Phone { get; set; }
        [MaxLength(100)]
        public string Salt { get; set; }
        [JsonIgnore]
        [MaxLength(100)]
        public string Password { get; set; }
    }
}
