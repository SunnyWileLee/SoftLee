using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Crm.Customer.Entities
{
    class CustomerPropertyValueEntity
    {
        public Guid CustomerId { get; set; }
        public Guid PropertyId { get; set; }
        public string Value { get; set; }
    }
}
