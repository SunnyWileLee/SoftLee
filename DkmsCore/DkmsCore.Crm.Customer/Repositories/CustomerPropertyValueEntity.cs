using DkmsCore.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Crm.Customer.Repositories
{
    [Table("CustomerPropertyValue")]
    public class CustomerPropertyValueEntity : DkmsPropertyValueEntity
    {
        [Column("CustomerId")]
        public override Guid InstanceId { get; set; }
    }
}
