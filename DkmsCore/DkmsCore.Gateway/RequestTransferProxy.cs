using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DkmsCore.Tools.Net;
using Microsoft.AspNetCore.Http;

namespace DkmsCore.Gateway
{
    class RequestTransferProxy : IRequestTransferProxy
    {
        private readonly IHttpExecuter _httpExecuter;

        public async Task Transfer(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}
