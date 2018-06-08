using DkmsCore.Eureka.Core.Entities;
using DkmsCore.Route;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Eureka.Core.Applications
{
    public interface IServiceDiscovery
    {
        List<DkmsApiEntity> Discovery(DkmsRoute route);
    }
}
