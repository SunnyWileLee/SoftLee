using DkmsCore.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Gms.Stock.Repositories
{
    [Table("GoodsStockReason")]
    public class GoodsStockReasonEntity : DkmsUserEntity
    {
        public GoodsStockReasonCategory Category { get; set; }
        [MaxLength(100)]
        public string Content { get; set; }
    }

    public enum GoodsStockReasonCategory
    {
        增加 = 1,
        减少 = 2
    }
}
