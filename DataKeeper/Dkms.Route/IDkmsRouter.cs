using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Dkms.Route
{
    public interface IDkmsRouter
    {
        RouteContext Route(HttpRequestMessage request);
    }
}
