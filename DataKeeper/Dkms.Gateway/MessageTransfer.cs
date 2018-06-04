using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dkms.Tools.Net;

namespace Dkms.Gateway
{
    public abstract class MessageTransfer : IMessageTransfer
    {
        public abstract HttpMethod Method { get; }

        public abstract ApiResult Transfer(string url, HttpRequestMessage request);
        public abstract Task<ApiResult> TransferAsync(string url, HttpRequestMessage request);
    }
}
