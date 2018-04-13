using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Domain.Properties;
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
    [PropertyValue("CustomerId")]
    public class CustomerPropertyValueEntity : PropertyValueEntity
    {
        public Guid CustomerId { get; set; }

        public override void SetInstance(Guid id)
        {
            CustomerId = id;
        }
    }
}
