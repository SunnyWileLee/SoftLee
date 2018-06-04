using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dkms.Tools.Net;
using Newtonsoft.Json;

namespace Dkms.Gateway
{
    public class MessagePostTransfer : MessageTransfer
    {
        private readonly IHttpExecuter _httpExecuter;

        public MessagePostTransfer(IHttpExecuter httpExecuter)
        {
            _httpExecuter = httpExecuter;
        }

        public override HttpMethod Method => HttpMethod.Post;

        public override ApiResult Transfer(string url, HttpRequestMessage request)
        {
            var parameters = GetParameters(request);
            var headers = request.Headers.ToDictionary(key => key.Key, value => string.Join(" ", value.Value));
            var result = _httpExecuter.Post(url, parameters, headers);
            return JsonConvert.DeserializeObject<ApiResult>(result);
        }

        public async override Task<ApiResult> TransferAsync(string url, HttpRequestMessage request)
        {
            var parameters = GetParameters(request);
            var headers = request.Headers.ToDictionary(key => key.Key, value => string.Join(" ", value.Value));
            var result = await _httpExecuter.PostAsync(url, parameters, headers);
            return JsonConvert.DeserializeObject<ApiResult>(result);
        }

        private string GetParameters(HttpRequestMessage request)
        {
            using (var stream = request.Content.ReadAsStreamAsync().Result)
            {
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var requestData = reader.ReadToEnd();
                    return requestData;
                }
            }
        }
    }
}
