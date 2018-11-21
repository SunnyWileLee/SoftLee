using DkmsCore.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Gms.Stock.Repositories
{
    [Table("GoodsStock")]
    public class GoodsStockEntity : DkmsUserEntity
    {
        public Guid GoodsId { get; set; }
        public decimal Stock { get; set; }
    }
}
