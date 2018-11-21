using DkmsCore.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Gms.Goods.Repositories
{
    [Table("GoodsPropertyValue")]
    public class GoodsPropertyValueEntity : DkmsPropertyValueEntity
    {
        [Column("GoodsId")]
        public override Guid InstanceId { get; set; }
    }
}
