using DkmsCore.Stark.Models;
using DkmsCore.StarLord;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Thanos.Core
{
    public class TransferContext
    {
        public HttpContext HttpContext { get; set; }
        public DkmsRoute DkmsRoute { get; set; }
        public DkmsApi DkmsApi { get; set; }

        public string BuildUrl()
        {
            return DkmsApi.BuildUrl(HttpContext.Request.QueryString.ToString());
        }

        public Dictionary<string, string> BuildHeaders()
        {
            return HttpContext.Request.Headers.ToDictionary(key => key.Key, value => value.Value.ToString());
        }
    }
}
