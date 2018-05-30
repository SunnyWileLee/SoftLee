using System.Collections.Generic;
using Dkms.Eureka.Entities;

namespace Dkms.Eureka.Repositories
{
    public interface IServiceQueryRepository
    {
        IEnumerable<DkmsServiceEntity> Query(string host);
    }
}