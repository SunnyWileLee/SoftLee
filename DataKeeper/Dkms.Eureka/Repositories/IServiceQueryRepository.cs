using System.Collections.Generic;
using Dkms.Eureka.Entities;

namespace Dkms.Eureka.Repositories
{
    public interface IServiceQueryRepository
    {
        List<DkmsServiceEntity> QueryByHost(string host);
        List<DkmsServiceEntity> QueryByService(string service);
    }
}