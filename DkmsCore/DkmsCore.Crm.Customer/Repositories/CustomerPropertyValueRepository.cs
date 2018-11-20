using DkmsCore.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Crm.Customer.Repositories
{
    public class CustomerPropertyValueRepository : ICustomerPropertyValueRepository
    {
        private readonly IDkmsPropertyValueRepository _dkmsPropertyValueRepository;

        public async Task<Guid> AddPropertyValueEntity(Guid userId, CustomerPropertyValueEntity entity)
        {
            entity.UserId = userId;
            return await _dkmsPropertyValueRepository.AddAsync(entity);
        }

        public async Task<List<CustomerPropertyValueEntity>> GetList(Guid userId, IEnumerable<Guid> customerIds)
        {
            return await _dkmsPropertyValueRepository.GetListAsync<CustomerPropertyValueEntity>(userId, customerIds);
        }
    }
}
