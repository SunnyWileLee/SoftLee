using DataKeeper.Crm.Customer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Crm.Customer.Repositories
{
    class CustomerContext : DbContext
    {
        public CustomerContext(string name)
            : base(name)
        {

        }

        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<CustomerPropertyEntity> CustomerProperties { get; set; }
        public DbSet<CustomerPropertyValueEntity> CustomerPropertyValues { get; set; }
    }
}
