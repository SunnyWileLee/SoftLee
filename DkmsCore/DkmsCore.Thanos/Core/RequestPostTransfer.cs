using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace DkmsCore.Thanos.Core
{
    public class RequestPostTransfer : RequestTransfer
    {
        public RequestPostTransfer(IDkmsRouter dkmsRouter, IOptions<AppSettingOptions> appSettings, IBalancer balancer, IHttpExecuter httpExecuter) 
            : base(dkmsRouter, appSettings, balancer, httpExecuter)
        {
        }

        public override string Method => "POST";

        protected override async Task TransferMethodAsync(HttpContext context, string url, Dictionary<string, string> headers)
        {
            var requestData = string.Empty;
            using (StreamReader reader = new StreamReader(context.Request.Body, Encoding.UTF8))
            {
                requestData = await reader.ReadToEndAsync();
            }
            try
            {
                var data = await HttpExecuter.PostAsync(url, requestData, headers);
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
