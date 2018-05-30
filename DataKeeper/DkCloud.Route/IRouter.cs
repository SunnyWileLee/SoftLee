using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DkCloud.Route
{
    public interface IRouter
    {
        RouteData Route(Uri uri);
    }
}
