using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Avengers.Caches
{
    interface IRedisExpiryProvider
    {
        int Provide();
    }
}
