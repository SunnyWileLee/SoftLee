using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Crm.Customer.Models
{
    public class CustomerPropertyValueModel
    {
        public Guid CustomerId { get; set; }
        public Guid PropertyId { get; set; }
        public string Value { get; set; }
    }
}
