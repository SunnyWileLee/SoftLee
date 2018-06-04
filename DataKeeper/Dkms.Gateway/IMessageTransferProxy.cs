using Dkms.Tools.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Gateway
{
    interface IMessageTransferProxy
    {
        ApiResult Transger(string url, HttpRequestMessage request);
        Task<ApiResult> TransgerAsync(string url, HttpRequestMessage request);
    }
}
