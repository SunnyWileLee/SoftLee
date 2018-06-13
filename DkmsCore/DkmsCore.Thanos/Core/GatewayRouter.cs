using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Thanos.Core
{
    public class GatewayRouter : IRouter
    {
        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return new VirtualPathData(this, string.Empty) { };
        }

        public Task RouteAsync(RouteContext context)
        {
            context.RouteData = new RouteData { };
            context.Handler = new RequestDelegate((new RequestTransferProxy { }).Transfer);
            return Task.CompletedTask;
        }
    }
}
