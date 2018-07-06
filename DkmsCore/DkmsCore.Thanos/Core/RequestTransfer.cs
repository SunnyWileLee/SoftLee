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
        private readonly IDkmsRouter _dkmsRouter;
        private readonly IOptions<AppSettingOptions> _appSettings;
        private readonly IBalancer _balancer;
        private readonly IHttpExecuter _httpExecuter;

        protected RequestTransfer(IDkmsRouter dkmsRouter,
                                  IOptions<AppSettingOptions> appSettings,
                                  IBalancer balancer,
                                  IHttpExecuter httpExecuter)
        {
            _dkmsRouter = dkmsRouter;
            _appSettings = appSettings;
            _balancer = balancer;
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

        public async virtual Task Transfer(HttpContext context)
        {
            var route = _dkmsRouter.Route(context);
            var apis = await FindServiceAsync(route);
            var api = _balancer.Balance(apis);
            var url = api.BuildUrl(context.Request.QueryString.ToString());
            var headers = context.Request.Headers.ToDictionary(key => key.Key, value => value.Value.ToString());
            await TransferMethodAsync(context, url, headers);
        }

        protected abstract Task TransferMethodAsync(HttpContext context, string url, Dictionary<string, string> headers);

        private async Task<List<DkmsApi>> FindServiceAsync(DkmsRoute route)
        {
            var gamoras =  FindGamora();
            var gamora = _balancer.Balance(gamoras);
            var url = gamora.BuildUrl($"?service={route.Service}");
            var data = await _httpExecuter.GetAsync(url);
            return JsonConvert.DeserializeObject<List<DkmsApi>>(data);
        }

        private List<DkmsApi> FindGamora()
        {
            var gamoras =  _appSettings.Value.GatewayHost;
            return JsonConvert.DeserializeObject<List<DkmsApi>>(gamoras);
        }

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
