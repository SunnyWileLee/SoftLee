using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DkmsCore.Avengers;
using DkmsCore.Avengers.Net;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DkmsCore.Thanos.Core
{
    class RequestTransferProxy : IRequestTransferProxy
    {
        private readonly IRequestTransfer[] _transfers;

        public RequestTransferProxy(IRequestTransfer[] transfers)
        {
            _transfers = transfers;
        }

        public async Task Transfer(HttpContext context)
        {
            var transfer = _transfers.FirstOrDefault(s => s.Method == context.Request.Method);
            if (transfer == null)
            {
                await NotSupport(context);
            }
            await transfer.Transfer(context);
        }

        protected virtual async Task NotSupport(HttpContext context)
        {
            var result = ApiResult.Fail(message: $"{context.Request.Method}不被支持");
            await context.Response.WriteAsync(JsonConvert.SerializeObject(result), Encoding.UTF8);
        }
    }
}
