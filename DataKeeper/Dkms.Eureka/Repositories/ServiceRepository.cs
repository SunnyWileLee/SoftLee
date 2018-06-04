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
    class ServiceRepository : DkmsRepository, IServiceRepository
    {
        public ServiceRepository(IDbContextProvider dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public void Add(IEnumerable<DkmsServiceEntity> services)
        {
            using (var context = ContextProvider.Provide<EurekaDbContext>())
            {
                context.Services.AddRange(services);
                context.SaveChanges();
            }
        }

        public void Delete(IEnumerable<DkmsServiceEntity> services)
        {
            using (var context = ContextProvider.Provide<EurekaDbContext>())
            {
                context.Services.RemoveRange(services);
                context.SaveChanges();
            }
        }

        protected override DbContext CreateContext()
        {
            throw new NotImplementedException();
        }
    }
}
