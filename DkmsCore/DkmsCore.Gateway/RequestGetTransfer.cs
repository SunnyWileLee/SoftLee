using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DkmsCore.Gateway
{
    public class RequestGetTransfer : RequestTransfer
    {
        public override string Method => "GET";

        public override Task Transfer(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}
