using Dkms.Eureka.Entities;
using Dkms.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Eureka.Repositories
{
    class EurekaDbContext : DbContext
    {
        public EurekaDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        public DbSet<DkmsServiceEntity> Services { get; set; }
    }
}
