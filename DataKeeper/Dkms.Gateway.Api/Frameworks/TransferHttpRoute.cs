using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;

namespace Dkms.Gateway.Api.Frameworks
{
    public class TransferHttpRoute : IHttpRoute
    {
        public string RouteTemplate => "transfer";

        public IDictionary<string, object> Defaults => new Dictionary<string, object> { };

        public IDictionary<string, object> Constraints => new Dictionary<string, object> { };

        public IDictionary<string, object> DataTokens => new Dictionary<string, object> { };

        public HttpMessageHandler Handler => new TransferMessageHandler { };

        public IHttpRouteData GetRouteData(string virtualPathRoot, HttpRequestMessage request)
        {
            return new HttpRouteData(this, new HttpRouteValueDictionary { });
        }

        public IHttpVirtualPathData GetVirtualPath(HttpRequestMessage request, IDictionary<string, object> values)
        {
            return new HttpVirtualPathData(this, string.Empty);
        }
    }
}