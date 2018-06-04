using Dkms.Eureka.Domain;
using Dkms.Route;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Gateway
{
    class DkmsGateway : IDkmsGateway
    {
        private readonly IDkmsRouter _dkmsRouter;
        private readonly IServiceDiscovery _serviceDiscovery;
        private readonly IMessageTransferProxy _messageTransferProxy;

        public DkmsGateway(IDkmsRouter dkmsRouter, IServiceDiscovery serviceDiscovery, IMessageTransferProxy messageTransferProxy)
        {
            _dkmsRouter = dkmsRouter;
            _serviceDiscovery = serviceDiscovery;
            _messageTransferProxy = messageTransferProxy;
        }

        public HttpResponseMessage Invoke(HttpRequestMessage request)
        {
            var route = _dkmsRouter.Route(request);
            var services = _serviceDiscovery.Discovery(route.Service);
            var service = services.FirstOrDefault();
            var url = $"http://{service.Host}/{service.Service}";
            var result = _messageTransferProxy.Transger(url, request);
            return request.CreateResponse(HttpStatusCode.OK, result);
        }

        public async Task<HttpResponseMessage> InvokeAsync(HttpRequestMessage request)
        {
            var route = _dkmsRouter.Route(request);
            var services = _serviceDiscovery.Discovery(route.Service);
            var service = services.FirstOrDefault();
            var url = $"http://{service.Host}/{service.Service}";
            var result = await _messageTransferProxy.TransgerAsync(url, request);
            return request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
