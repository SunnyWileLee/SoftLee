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
    [Table("CustomerProperty")]
    [PropertyDescription(PropertyValueType = typeof(CustomerPropertyValueEntity))]
    public class CustomerPropertyEntity : PropertyEntity
    {

    }
}
