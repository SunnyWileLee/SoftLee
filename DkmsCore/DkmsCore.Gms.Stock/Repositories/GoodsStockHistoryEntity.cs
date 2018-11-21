using DkmsCore.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Gms.Stock.Repositories
{
    [Table("GoodsStockHistory")]
    public class GoodsStockHistoryEntity : DkmsUserEntity
    {
        public Guid GoodsId { get; set; }
        public decimal Stock { get; set; }
        [MaxLength(500)]
        public string Memo { get; set; }
    }
}
