using DataKeeper.Framework.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Crm.Customer.Entities
{
    [Table("CustomerPropertyValue")]
    class CustomerPropertyValueEntity : PropertyValueEntity
    {
        public const string InstanceKey = "CustomerId";

        public Guid CustomerId { get; set; }
    }
}
