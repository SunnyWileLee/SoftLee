using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dkms.Eureka.Entities;
using Dkms.Eureka.Repositories;

namespace Dkms.Eureka.Domain
{
    class ServiceDiscovery : IServiceDiscovery
    {
        private readonly IServiceQueryRepository _serviceQueryRepository;

        public ServiceDiscovery(IServiceQueryRepository serviceQueryRepository)
        {
            _serviceQueryRepository = serviceQueryRepository;
        }

        public List<DkmsServiceEntity> Discovery(string service)
        {
            return _serviceQueryRepository.QueryByService(service);
        }
    }
}
