using DkmsCore.Avengers.Configs;
using DkmsCore.Thanos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Thanos.Core
{
    public class GatewayRouter : IGatewayRouter
    {
        private readonly IRequestTransferProxy _requestTransferProxy;

        public GatewayRouter(IRequestTransferProxy requestTransferProxy)
        {
            _requestTransferProxy = requestTransferProxy;
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return new VirtualPathData(this, string.Empty) { };
        }

        public Task RouteAsync(RouteContext context)
        {
            context.RouteData = new RouteData { };
            context.Handler = new RequestDelegate(_requestTransferProxy.Transfer);
            return Task.CompletedTask;
        }
    }
}
