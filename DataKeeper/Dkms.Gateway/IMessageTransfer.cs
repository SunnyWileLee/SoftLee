using Dkms.Tools.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Gateway
{
    interface IMessageTransfer
    {
        HttpMethod Method { get;}
        ApiResult Transfer(string url,HttpRequestMessage request);
        Task<ApiResult> TransferAsync(string url, HttpRequestMessage request);
    }
}
