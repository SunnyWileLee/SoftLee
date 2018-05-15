using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Gateway
{
    public interface IDkmsGateway
    {
        HttpResponseMessage Invoke(HttpRequestMessage request);
    }
}
