using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DkmsCore.Avengers.Net;
using Microsoft.AspNetCore.Http;

namespace DkmsCore.Thanos.Core
{
    public class RequestPostTransfer : RequestTransfer
    {
        private readonly IHttpExecuter _httpExecuter;

        public override string Method => "POST";

        public override Task Transfer(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}
