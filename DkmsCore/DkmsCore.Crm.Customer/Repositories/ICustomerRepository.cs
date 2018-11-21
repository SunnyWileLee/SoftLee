using DkmsCore.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DkmsCore.Crm.Customer.Repositories
{
    public interface ICustomerRepository
    {
        Task<Guid> AddAsync(Guid userId,CustomerEntity customer);
        Task<DkmsPage<CustomerEntity>> GetPageAsync(Expression<Func<CustomerEntity, bool>> predicate, DkmsPageQuery query);
        Task<DkmsPage<CustomerEntity>> GetPageAsync(Guid userId, DkmsPageQuery query);
    }
}
