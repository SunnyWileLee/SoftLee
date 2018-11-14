using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Infrustructure.Caches
{
    interface IRedisExpiryProvider
    {
        int Provide();
    }
}
