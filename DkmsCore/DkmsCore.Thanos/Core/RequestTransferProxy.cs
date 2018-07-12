using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DkmsCore.Avengers;
using DkmsCore.Avengers.Configs;
using DkmsCore.Avengers.Net;
using DkmsCore.Stark.Applications;
using DkmsCore.Stark.Models;
using DkmsCore.StarLord;
using DkmsCore.Thanos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DkmsCore.Thanos.Core
{
    class RequestTransferProxy : IRequestTransferProxy
    {
        private readonly IRequestTransfer[] _transfers;
        private readonly IDkmsRouter _dkmsRouter;
        private readonly IOptions<ThanosAppSettings> _appSettings;
        private readonly IBalancer _balancer;
        private readonly IHttpExecuter _httpExecuter;

        public RequestTransferProxy(IRequestTransfer[] transfers, IDkmsRouter dkmsRouter, IOptions<ThanosAppSettings> appSettings, IBalancer balancer, IHttpExecuter httpExecuter)
        {
            _transfers = transfers;
            _dkmsRouter = dkmsRouter;
            _appSettings = appSettings;
            _balancer = balancer;
            _httpExecuter = httpExecuter;
        }

        public async Task Transfer(HttpContext context)
        {
            var transfer = _transfers.FirstOrDefault(s => s.Method == context.Request.Method);
            if (transfer == null)
            {
                await NotSupport(context);
            }
            var route = _dkmsRouter.Route(context);
            var apis = await FindServiceAsync(route);
            var api = _balancer.Balance(apis);

            var transferContext = new TransferContext
            {
                DkmsApi = api,
                DkmsRoute = route,
                HttpContext = context
            };

            await transfer.Transfer(transferContext);
        }

        private async Task<List<DkmsApi>> FindServiceAsync(DkmsRoute route)
        {
            var gamoras = _appSettings.Value.Gamoras;
            var gamora = _balancer.Balance(gamoras);
            var url = gamora.BuildUrl($"?service={route.Service}");
            var data = await _httpExecuter.GetAsync(url);
            return JsonConvert.DeserializeObject<List<DkmsApi>>(data);
        }

        private async Task NotSupport(HttpContext context)
        {
            var result = ApiResult.Fail(message: $"{context.Request.Method}不被支持");
            await context.Response.WriteAsync(JsonConvert.SerializeObject(result), Encoding.UTF8);
        }
    }
}
