using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DkmsCore.Avengers;
using DkmsCore.Avengers.Configs;
using DkmsCore.Avengers.Net;
using DkmsCore.Stark.Applications;
using DkmsCore.StarLord;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DkmsCore.Thanos.Core
{
    public class RequestGetTransfer : RequestTransfer
    {
        public RequestGetTransfer(IDkmsRouter dkmsRouter, IAppSettings appSettings, IBalancer balancer, IHttpExecuter httpExecuter)
            : base(dkmsRouter, appSettings, balancer, httpExecuter)
        {
        }

        public override string Method => "GET";

        protected override async Task TransferMethodAsync(HttpContext context, string url, Dictionary<string, string> headers)
        {
            try
            {
                var data = await HttpExecuter.GetAsync(url, headers);
                await context.Response.WriteAsync(data, Encoding.UTF8);
            }
            catch (WebException ex)
            {
                await base.HandleWebException(context, ex);
            }
            catch (Exception ex)
            {
                await base.HandleException(context, ex);
            }
        }
    }
}
