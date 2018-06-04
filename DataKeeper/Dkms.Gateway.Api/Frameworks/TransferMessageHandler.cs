using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Dkms.Gateway.Api.Frameworks
{
    public class TransferMessageHandler : DelegatingHandler
    {
        private IDkmsGateway _dkmsGateway;
        public readonly object GatewayLock = new object();

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_dkmsGateway == null)
            {
                lock (GatewayLock)
                {
                    if (_dkmsGateway == null)
                    {
                        _dkmsGateway = request.GetRequestContext().Configuration.DependencyResolver.GetService(typeof(IDkmsGateway)) as IDkmsGateway;
                    }
                }
            }
            var response = await _dkmsGateway.InvokeAsync(request);
            return response;
        }
    }
}