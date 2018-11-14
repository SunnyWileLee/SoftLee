using DkmsCore.Persistence;
using DkmsCore.Persistence.Repositories;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DkmsCore.Crm.Customer.Repositories
{
    public class CustomerRepository : DkmsRepository, ICustomerRepository
    {
        public CustomerRepository(CrmCustomerDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Guid> AddCustomer(CustomerEntity customer)
        {
            return await base.AddEntity(customer);
        }

        public async Task<DkmsEntityPage<CustomerEntity>> GetPage(Expression<Func<CustomerEntity, bool>> predicate, DkmsEntityPageQuery query)
        {
            return await base.GetPage(predicate, query);
        }

        public async Task<DkmsEntityPage<CustomerEntity>> GetPage(Guid userId, DkmsEntityPageQuery query)
        {
            return await base.GetPage<CustomerEntity>(s => s.UserId == userId, query);
        }


    }
}
