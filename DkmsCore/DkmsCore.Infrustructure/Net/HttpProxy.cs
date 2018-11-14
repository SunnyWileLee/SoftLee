using DkmsCore.Infrustructure.Configs;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Infrustructure.Net
{
    public abstract class HttpProxy
    {
        private readonly IOptionsSnapshot<AppSettingOptions> _appSettings;

        protected HttpProxy(IOptionsSnapshot<AppSettingOptions> appSettings)
        {
            _appSettings = appSettings;
        }

        protected HttpProxy()
        {

        }

        protected virtual string BuildUrl(string action)
        {
            return BuildUrl(action, string.Empty);
        }

        protected virtual string BuildUrl(string action, string query)
        {
            return $"http://{_appSettings.Value.GatewayHost}/{action}?{query}";
        }
    }
}
