﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Route
{
    public class DkmsRouter : IDkmsRouter
    {
        public RouteContext Route(HttpRequestMessage request)
        {
            return new RouteContext { };
        }
    }
}
