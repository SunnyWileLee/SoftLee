using DkmsCore.Crm.Customer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Crm.Customer.Models
{
    public class CustomerModel
    {
        public CustomerEntity Customer { get; set; }
        public List<CustomerPropertyValueEntity> Values { get; set; } = new List<CustomerPropertyValueEntity> { };
    }
}
