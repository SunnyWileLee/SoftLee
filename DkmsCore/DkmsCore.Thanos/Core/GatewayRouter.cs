using DkmsCore.Avengers.Configs;
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
        private readonly IOptions<AppSettingOptions> _appSettingsOption;

        public GatewayRouter(IRequestTransferProxy requestTransferProxy, IOptions<AppSettingOptions> appSettingsOption)
        {
            _requestTransferProxy = requestTransferProxy;
            _appSettingsOption = appSettingsOption;
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return new VirtualPathData(this, string.Empty) { };
        }

        public Task RouteAsync(RouteContext context)
        {
            var values = _appSettingsOption.Value;
            context.RouteData = new RouteData { };
            context.Handler = new RequestDelegate(_requestTransferProxy.Transfer);
            return Task.CompletedTask;
        }
    }
}
