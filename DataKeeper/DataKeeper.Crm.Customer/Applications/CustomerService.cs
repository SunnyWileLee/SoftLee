using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataKeeper.Crm.Customer.Entities;
using DataKeeper.Crm.Customer.Models;
using DataKeeper.Crm.Customer.Repositories;
using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Repositories;

namespace DataKeeper.Crm.Customer.Applications
{
    class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IPropertyValueRepositoryProvider _propertyValueRepositoryProvider;
        private readonly ICustomerContextProvider _customerContextProvider;

        public CustomerService(ICustomerRepository customerRepository, 
                               IPropertyValueRepositoryProvider propertyValueRepositoryProvider, 
                               ICustomerContextProvider customerContextProvider)
        {
            _customerRepository = customerRepository;
            _propertyValueRepositoryProvider = propertyValueRepositoryProvider;
            _customerContextProvider = customerContextProvider;
        }

        public Guid Add(CustomerModel model)
        {
            var userId = UserContext.Current.UserId;
            var customer = Mapper.Map<CustomerEntity>(model);
            var customerId = _customerRepository.Add(customer);
            if (customerId != Guid.Empty)
            {
                var values = Mapper.Map<List<CustomerPropertyValueEntity>>(model.Properties.ToList());
                values.ForEach(value =>
                {
                    value.UserId = userId;
                    value.CustomerId = customerId;
                });
                var context = new SetPropertyValueContext<CustomerPropertyValueEntity>
                {
                    ContextProvider = _customerContextProvider,
                    InstanceId = customerId,
                    KeyProperty = CustomerPropertyValueEntity.InstanceKey,
                    UserId = userId,
                    PropertyValues = values
                };
                _propertyValueRepositoryProvider.Provide().SetValues(context);
            }
            return customerId;
        }
    }
}
