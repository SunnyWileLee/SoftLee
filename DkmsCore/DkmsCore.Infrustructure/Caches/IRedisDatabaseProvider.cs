using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Infrustructure.Caches
{
    interface IRedisDatabaseProvider
    {
        IDatabase Provide();
    }
}
