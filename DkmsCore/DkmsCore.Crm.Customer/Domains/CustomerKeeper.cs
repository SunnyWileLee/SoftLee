using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DkmsCore.Crm.Customer.Models;
using DkmsCore.Crm.Customer.Repositories;
using DkmsCore.Infrustructure.Securitys;

namespace DkmsCore.Crm.Customer.Domains
{
    public class CustomerKeeper : ICustomerKeeper
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerPropertyValueRepository _customerPropertyValueRepository;

        public CustomerKeeper(ICustomerRepository customerRepository, ICustomerPropertyValueRepository customerPropertyValueRepository)
        {
            _customerRepository = customerRepository;
            _customerPropertyValueRepository = customerPropertyValueRepository;
        }

        public async Task<Guid> Add(CustomerModel model)
        {
            var userId = DkmsUserContext.UserIdDefaultEmpty;
            var customerId = await _customerRepository.AddCustomer(userId, model.Customer);
            if (model.Values.Any())
            {
                foreach (var value in model.Values)
                {
                    value.InstanceId = customerId;
                    await _customerPropertyValueRepository.AddPropertyValueEntity(userId, value);
                }
            }
            return customerId;
        }
    }
}
