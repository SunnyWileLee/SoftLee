using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Avengers.Caches
{
    interface IRedisDatabaseProvider
    {
        IDatabase Provide();
    }
}
