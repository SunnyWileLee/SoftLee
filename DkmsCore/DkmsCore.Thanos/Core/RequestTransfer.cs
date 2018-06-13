using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DkmsCore.Avengers.Configs;
using DkmsCore.Avengers.Net;
using DkmsCore.Stark;
using DkmsCore.Stark.Applications;
using DkmsCore.Stark.Models;
using DkmsCore.StarLord;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DkmsCore.Thanos.Core
{
    public abstract class RequestTransfer : IRequestTransfer
    {
        private readonly IDkmsRouter _dkmsRouter;
        private readonly IAppSettings _appSettings;
        private readonly IBalancer _balancer;
        private readonly IHttpExecuter _httpExecuter;

        public abstract string Method { get; }

        public async virtual Task Transfer(HttpContext context)
        {
            var route = _dkmsRouter.Route(context);
            var apis = await FindServiceAsync(route);
            var api = _balancer.Balance(apis);
            var url = api.BuildUrl(context.Request.QueryString.ToString());
            var headers = context.Request.Headers.ToDictionary(key => key.Key, value => value.Value.ToString());
        }

        private async Task<List<DkmsApi>> FindServiceAsync(DkmsRoute route)
        {
            var gamoras = FindGamora();
            var gamora = _balancer.Balance(gamoras);
            var url = gamora.BuildUrl($"?service={route.Service}");
            var data = await _httpExecuter.GetAsync(url);
            return JsonConvert.DeserializeObject<List<DkmsApi>>(data);
        }

        private List<DkmsApi> FindGamora()
        {
            return new List<DkmsApi> { };
        }
    }
}
