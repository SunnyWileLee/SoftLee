using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Crm.Customer.Repositories
{
    public class CrmCustomerDbContext : DbContext
    {
        public CrmCustomerDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<CustomerPropertyEntity> CustomerProperties { get; set; }
        public DbSet<CustomerPropertyValueEntity> CustomerPropertyValues { get; set; }
    }
}
