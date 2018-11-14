using DkmsCore.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Crm.Customer.Repositories
{
    [Table("Customer")]
    public class CustomerEntity : DkmsUserEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Phone { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
    }
}
