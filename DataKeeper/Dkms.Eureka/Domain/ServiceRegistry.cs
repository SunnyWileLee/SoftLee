using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dkms.Eureka.Entities;
using Dkms.Eureka.Models;
using Dkms.Eureka.Repositories;

namespace Dkms.Eureka.Domain
{
    class ServiceRegistry : IServiceRegistry
    {
        private readonly IServiceQueryRepository _serviceQueryRepository;
        private readonly IServiceRepository _serviceRepository;

        public void Register(ServiceCollection services)
        {
            var list = services.Services
                               .Select(s => new DkmsServiceEntity
                               {
                                   Host = services.Host,
                                   Service = s
                               }).ToList();
            var currents = _serviceQueryRepository.Query(services.Host);
            var news = list.Where(s => !currents.Any(x => s.Service == s.Service));
        }
    }
}
