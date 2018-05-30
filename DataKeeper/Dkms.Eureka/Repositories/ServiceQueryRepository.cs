using Dkms.Eureka.Entities;
using Dkms.Repository;
using System;
using System.Collections.Generic;
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

        public IEnumerable<DkmsServiceEntity> Query(string host)
        {
            using (var context = ContextProvider.Provide<EurekaDbContext>())
            {
                return context.Services.Where(s => s.Host == host).ToList();
            }
        }
    }
}
