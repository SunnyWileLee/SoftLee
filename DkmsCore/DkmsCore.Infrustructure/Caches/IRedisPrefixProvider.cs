using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Infrustructure.Caches
{
    interface IRedisPrefixProvider
    {
        string Provide();
    }
}
