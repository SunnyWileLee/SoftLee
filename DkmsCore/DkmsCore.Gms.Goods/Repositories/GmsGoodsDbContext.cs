using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Gms.Goods.Repositories
{
    public class GmsGoodsDbContext : DbContext
    {
        public GmsGoodsDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<GoodsEntity> Goods { get; set; }
        public DbSet<GoodsPropertyEntity> GoodsProperties { get; set; }
        public DbSet<GoodsPropertyValueEntity> GoodsPropertyValues { get; set; }
    }
}
