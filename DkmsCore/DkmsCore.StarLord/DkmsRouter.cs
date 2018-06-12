using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace DkmsCore.StarLord
{
    public class DkmsRouter : IDkmsRouter
    {
        public DkmsRoute Route(HttpContext context)
        {
            return new DkmsRoute
            {
                Service = context.Request.Path.ToString()
            };
        }
    }
}
