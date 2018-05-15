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

        public HttpResponseMessage Invoke(HttpRequestMessage request)
        {
            var route = _dkmsRouter.Route(request);
            throw new NotImplementedException();
        }
    }
}
