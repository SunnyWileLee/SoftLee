using System.Collections.Generic;
using Dkms.Eureka.Entities;

namespace Dkms.Eureka.Repositories
{
    public interface IServiceRepository
    {
        void Add(IEnumerable<DkmsServiceEntity> services);
    }
}