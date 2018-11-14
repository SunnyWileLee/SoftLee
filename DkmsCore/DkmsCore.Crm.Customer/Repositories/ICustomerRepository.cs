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
        Task<Guid> AddCustomer(CustomerEntity customer);
        Task<DkmsPage<CustomerEntity>> GetPage(Expression<Func<CustomerEntity, bool>> predicate, DkmsPageQuery query);
        Task<DkmsPage<CustomerEntity>> GetPage(Guid userId, DkmsPageQuery query);
    }
}
