using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DkmsCore.Avengers;
using DkmsCore.Avengers.Configs;
using DkmsCore.Avengers.Net;
using DkmsCore.Stark;
using DkmsCore.Stark.Applications;
using DkmsCore.Stark.Models;
using DkmsCore.StarLord;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DkmsCore.Thanos.Core
{
    public abstract class RequestTransfer : IRequestTransfer
    {
        private readonly IHttpExecuter _httpExecuter;

        protected RequestTransfer(IHttpExecuter httpExecuter)
        {
            _httpExecuter = httpExecuter;
        }

        public abstract string Method { get; }

        public IHttpExecuter HttpExecuter
        {
            get
            {
                return _httpExecuter;
            }
        }

        public async virtual Task Transfer(TransferContext context)
        {
            var url = context.BuildUrl();
            var headers = context.BuildHeaders();
            await TransferMethodAsync(context.HttpContext, url, headers);
        }

        protected abstract Task TransferMethodAsync(HttpContext context, string url, Dictionary<string, string> headers);

        protected virtual async Task HandleWebException(HttpContext context, WebException ex)
        {
            var response = ex.Response as HttpWebResponse;
            var result = ApiResult.Fail(response.StatusCode.GetHashCode(), ex.Message);
            await context.Response.WriteAsync(JsonConvert.SerializeObject(result), Encoding.UTF8);
        }

        protected virtual async Task HandleException(HttpContext context, Exception ex)
        {
            await context.Response.WriteAsync(JsonConvert.SerializeObject(ApiResult.Fail(message: ex.Message)), Encoding.UTF8);
        }
    }
}
