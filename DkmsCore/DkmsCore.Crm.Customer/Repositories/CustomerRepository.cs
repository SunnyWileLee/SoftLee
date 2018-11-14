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

        public async Task<DkmsPage<CustomerEntity>> GetPage(Expression<Func<CustomerEntity, bool>> predicate, DkmsPageQuery query)
        {
            return await base.GetPage(predicate, query);
        }

        public async Task<DkmsPage<CustomerEntity>> GetPage(Guid userId, DkmsPageQuery query)
        {
            return await base.GetPage<CustomerEntity>(s => s.UserId == userId, query);
        }


    }
}
