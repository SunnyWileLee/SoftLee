using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Oms.Order.Repositories
{
    public class OmsOrderDbContext : DbContext
    {
        public OmsOrderDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<OrdersEntity> Orders { get; set; }
    }
}
