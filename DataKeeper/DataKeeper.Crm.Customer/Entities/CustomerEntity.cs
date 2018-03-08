using DataKeeper.Framework.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Crm.Customer.Entities
{
    [Table("Customer")]
    class CustomerEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
