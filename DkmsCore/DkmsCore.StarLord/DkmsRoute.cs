using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.StarLord
{
    public class DkmsRoute
    {
        public HttpContext HttpContext { get; set; }
        public string Service { get; set; }
        public string QueryString { get; set; }
    }
}
