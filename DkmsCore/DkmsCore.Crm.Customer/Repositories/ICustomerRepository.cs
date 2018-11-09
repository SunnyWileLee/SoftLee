using DkmsCore.Thor;
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
        Task<DkmsEntityPage<CustomerEntity>> GetPage(Expression<Func<CustomerEntity, bool>> predicate, DkmsEntityPageQuery query);
        Task<DkmsEntityPage<CustomerEntity>> GetPage(Guid userId, DkmsEntityPageQuery query);
    }
}
