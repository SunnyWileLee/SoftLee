using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Gms.Stock.Repositories
{
    public class GmsStockDbContext : DbContext
    {
        public GmsStockDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<GoodsStockEntity> GoodsStocks { get; set; }
        public DbSet<GoodsStockHistoryEntity> GoodsStockHistories { get; set; }
        public DbSet<GoodsStockReasonEntity> GoodsStockReasons { get; set; }
    }
}
