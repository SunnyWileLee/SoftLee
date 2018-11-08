using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Avengers.Caches
{
    interface IRedisPrefixProvider
    {
        string Provide();
    }
}
