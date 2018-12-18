using DkmsCore.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Oms.Order.Repositories
{
    [Table("OrdersPropertyValue")]
    public class OrdersPropertyValueEntity : DkmsPropertyValueEntity
    {
        [Column("OrdersId")]
        public override Guid InstanceId { get; set; }
    }
}
