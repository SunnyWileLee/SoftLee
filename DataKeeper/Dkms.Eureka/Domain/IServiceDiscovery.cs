using Dkms.Eureka.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Eureka.Domain
{
    public interface IServiceDiscovery
    {
        List<DkmsServiceEntity> Discovery(string service);
    }
}
