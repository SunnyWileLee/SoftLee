using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DkmsCore.Crm.Customer.Models;
using DkmsCore.Crm.Customer.Repositories;
using DkmsCore.Infrustructure.Securitys;
using DkmsCore.Persistence.Repositories;

namespace DkmsCore.Crm.Customer.Domains
{
    public class CustomerKeeper : ICustomerKeeper
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDkmsPropertyValueRepository _dkmsPropertyValueRepository;

        public CustomerKeeper(ICustomerRepository customerRepository, IDkmsPropertyValueRepository dkmsPropertyValueRepository)
        {
            _customerRepository = customerRepository;
            _dkmsPropertyValueRepository = dkmsPropertyValueRepository;
        }

        public async Task<Guid> AddAsync(CustomerModel model)
        {
            var userId = DkmsUserContext.UserIdDefaultEmpty;
            var customerId = await _customerRepository.AddAsync(userId, model.Customer);
            if (model.Values.Any())
            {
                foreach (var value in model.Values)
                {
                    value.InstanceId = customerId;
                    await _dkmsPropertyValueRepository.AddAsync(userId, value);
                }
            }
            return customerId;
        }
    }
}
