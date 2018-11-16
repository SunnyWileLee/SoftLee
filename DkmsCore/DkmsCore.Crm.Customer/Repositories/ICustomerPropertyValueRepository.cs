using DkmsCore.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Crm.Customer.Repositories
{
    public interface ICustomerPropertyValueRepository
    {
        Task<Guid> AddPropertyValueEntity(Guid userId, CustomerPropertyValueEntity entity);
        Task<List<CustomerPropertyValueEntity>> GetList(Guid userId, IEnumerable<Guid> customerIds);
    }
}
