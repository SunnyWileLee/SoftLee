using DataKeeper.Crm.Customer.Domain;
using DataKeeper.Framework.Entities;
using DataKeeper.Infrustructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Crm.Customer.Entities
{
    [Table("Customer"), ScopeEntity(CrmCustomerScoper.ScopeValue)]
    public class CustomerEntity : UserEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
