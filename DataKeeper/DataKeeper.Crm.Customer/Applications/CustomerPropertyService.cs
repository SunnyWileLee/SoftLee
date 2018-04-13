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
using DataKeeper.Framework.Domain.Properties;
using DataKeeper.Framework.Repositories;
using DataKeeper.Framework.Repositories.Entities;
using DataKeeper.Framework.Repositories.Properties;

namespace DataKeeper.Crm.Customer.Applications
{
    class CustomerPropertyService : ICustomerPropertyService
    {
        private readonly ICustomerContextProvider _customerContextProvider;
        private readonly IPropertyAddRepositoryProvider _propertyRepositoryProvider;

        public CustomerPropertyService(ICustomerContextProvider customerContextProvider,
                               IPropertyAddRepositoryProvider propertyRepositoryProvider)
        {
            _customerContextProvider = customerContextProvider;
            _propertyRepositoryProvider = propertyRepositoryProvider;
        }

        public Guid Add(CustomerPropertyModel model)
        {
            var property = Mapper.Map<CustomerPropertyEntity>(model);
            var context = new AddPropertyContext<CustomerPropertyEntity>
            {
                Property = property,
                ContextProvider = _customerContextProvider
            };
            var repository = _propertyRepositoryProvider.Provide();
            return repository.Add(context);
        }
    }
}
