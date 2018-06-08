﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Gateway
{
    public interface IRequestTransferProxy
    {
        Task Transfer(HttpContext context);
    }
}
