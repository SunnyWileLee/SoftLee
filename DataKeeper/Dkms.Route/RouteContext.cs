﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Route
{
    public class RouteContext
    {
        public HttpRequestMessage Request { get; set; }
        public string Service { get; set; }
    }
}
