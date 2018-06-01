using Dkms.Eureka.Domain;
using Dkms.Route;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Gateway
{
    class DkmsGateway : IDkmsGateway
    {
        private readonly IDkmsRouter _dkmsRouter;
        private readonly IServiceDiscovery _serviceDiscovery;

        public HttpResponseMessage Invoke(HttpRequestMessage request)
        {
            var route = _dkmsRouter.Route(request);
            var services = _serviceDiscovery.Discovery(route.Service);
            throw new NotImplementedException { };
        }
    }
}
