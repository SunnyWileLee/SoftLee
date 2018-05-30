using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DkCloud.Eureka
{
    public interface IServiceProvider
    {
        void Register(IEnumerable<ServiceEntity> services);
    }
}
