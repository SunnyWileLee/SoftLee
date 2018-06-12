using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DkmsCore.Eureka.Core.Entities;
using DkmsCore.StarLord;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DkmsCore.Gateway
{
    public abstract class RequestTransfer : IRequestTransfer
    {
        private readonly IDkmsRouter _dkmsRouter;

        public abstract string Method { get; }

        public async virtual Task Transfer(HttpContext context)
        {
            var route = _dkmsRouter.Route(context);
            var apis = await FindApis(program, service);
            var api = apis.FirstOrDefault();
            var url = api.ToUrl(context.Request.QueryString.ToString());
            var headers = context.Request.Headers.ToDictionary(key => key.Key, value => value.Value.ToString());
        }

        private async Task<List<DkmsApiEntity>> FindApisAsync(DkmsRoute route)
        {
            var url = $"http://120.55.73.39:5633/api/service/discovery?program={program}&service={service}";
            var data = await executer.GetAsync(url);
            return JsonConvert.DeserializeObject<List<MsApi>>(data);
        }
    }
}
