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
    class ServiceQueryRepository : DkmsRepository, IServiceQueryRepository
    {
        public ServiceQueryRepository(IDbContextProvider dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public List<DkmsServiceEntity> QueryByHost(string host)
        {
            using (var context = ContextProvider.Provide<EurekaDbContext>())
            {
                return context.Services.Where(s => s.Host == host).ToList();
            }
        }

        public List<DkmsServiceEntity> QueryByService(string service)
        {
            using (var context = ContextProvider.Provide<EurekaDbContext>())
            {
                return context.Services.Where(s => s.Service == service).ToList();
            }
        }

        protected override DbContext CreateContext()
        {
            throw new NotImplementedException();
        }
    }
}
