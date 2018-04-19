using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataKeeper.Crm.Customer.Entities;
using DataKeeper.Crm.Customer.Models;
using DataKeeper.Crm.Customer.Repositories;
using DataKeeper.Framework.Applications;
using DataKeeper.Framework.Domain;
using DataKeeper.Framework.Domain.Properties;
using DataKeeper.Framework.Repositories;
using DataKeeper.Framework.Repositories.Entities;
using DataKeeper.Framework.Repositories.Properties;

namespace DataKeeper.Crm.Customer.Applications
{
    class CustomerPropertyService : ICustomerPropertyService
    {
        private readonly IGenericServiceProvider _genericServiceProvider;

        public CustomerPropertyService(IGenericServiceProvider genericServiceProvider)
        {
            _genericServiceProvider = genericServiceProvider;
        }

        public Guid Add(CustomerPropertyModel model)
        {
            var repository = _genericServiceProvider.Provide<IPropertyAddService<CustomerPropertyEntity>>();
            return repository.Add(model);
        }

        public List<CustomerPropertyModel> GetList()
        {
            var repository = _genericServiceProvider.Provide<IPropertyQueryService<CustomerPropertyEntity>>();
            var properties = repository.Query<CustomerPropertyModel>();
            return properties;
        }
    }
}
