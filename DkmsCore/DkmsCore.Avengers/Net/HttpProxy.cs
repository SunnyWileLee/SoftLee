using DkmsCore.Avengers.Configs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Avengers.Net
{
    public abstract class HttpProxy
    {
        private readonly IAppSettings _appSettings;

        protected HttpProxy(IAppSettings appSettings)
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
            return $"http://{_appSettings.GatewayHost}/{action}?{query}";
        }
    }
}
