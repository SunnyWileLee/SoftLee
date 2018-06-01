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

        public ServiceRegistry(IServiceQueryRepository serviceQueryRepository, 
                               IServiceRepository serviceRepository)
        {
            _serviceQueryRepository = serviceQueryRepository;
            _serviceRepository = serviceRepository;
        }

        public void Register(ServiceCollection services)
        {
            var list = services.Services
                               .Select(s => new DkmsServiceEntity
                               {
                                   Host = services.Host,
                                   Service = s
                               }).ToList();
            var currents = _serviceQueryRepository.QueryByHost(services.Host);
            var news = list.Where(s => !currents.Any(x => s.Service == s.Service));
            _serviceRepository.Add(news);
            var removes = currents.Where(s => !news.Any(x => s.Service == s.Service));
            _serviceRepository.Delete(removes);
        }
    }
}
