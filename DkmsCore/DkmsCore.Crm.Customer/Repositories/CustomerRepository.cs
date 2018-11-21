using DkmsCore.Persistence;
using DkmsCore.Persistence.Repositories;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DkmsCore.Crm.Customer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDkmsRepository _dkmsRepository;

        public CustomerRepository(IDkmsRepository dkmsRepository)
        {
            _dkmsRepository = dkmsRepository;
        }

        public async Task<Guid> AddAsync(Guid userId, CustomerEntity customer)
        {
            customer.UserId = userId;
            return await _dkmsRepository.AddAsync(customer);
        }

        public async Task<DkmsPage<CustomerEntity>> GetPageAsync(Expression<Func<CustomerEntity, bool>> predicate, DkmsPageQuery query)
        {
            return await _dkmsRepository.GetPageAsync(predicate, query);
        }

        public async Task<DkmsPage<CustomerEntity>> GetPageAsync(Guid userId, DkmsPageQuery query)
        {
            return await _dkmsRepository.GetPageAsync<CustomerEntity>(s => s.UserId == userId, query);
        }
    }
}
