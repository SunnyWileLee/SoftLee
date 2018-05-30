using Dkms.Eureka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Eureka.Domain
{
    public interface IServiceRegistry
    {
        void Register(ServiceCollection services);
    }
}
