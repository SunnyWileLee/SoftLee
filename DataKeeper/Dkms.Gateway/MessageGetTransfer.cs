using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dkms.Tools.Net;
using Newtonsoft.Json;

namespace Dkms.Gateway
{
    public class MessageGetTransfer : MessageTransfer
    {
        private readonly IHttpExecuter _httpExecuter;

        public MessageGetTransfer(IHttpExecuter httpExecuter)
        {
            _httpExecuter = httpExecuter;
        }

        public override HttpMethod Method => HttpMethod.Get;

        public override ApiResult Transfer(string url, HttpRequestMessage request)
        {
            var headers = request.Headers.ToDictionary(key => key.Key, value => string.Join(" ", value.Value));
            var result = _httpExecuter.Get(url, headers);
            return JsonConvert.DeserializeObject<ApiResult>(result);
        }

        public async override Task<ApiResult> TransferAsync(string url, HttpRequestMessage request)
        {
            var headers = request.Headers.ToDictionary(key => key.Key, value => string.Join(" ", value.Value));
            var result = await _httpExecuter.GetAsync(url, headers);
            return JsonConvert.DeserializeObject<ApiResult>(result);
        }
    }
}
