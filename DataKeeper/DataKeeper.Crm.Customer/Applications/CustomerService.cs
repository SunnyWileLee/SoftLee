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
using DataKeeper.Framework.Repositories;

namespace DataKeeper.Crm.Customer.Applications
{
    class CustomerService : ICustomerService
    {
        private readonly IGenericServiceProvider _serviceProvider;

        public CustomerService(IGenericServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Guid Add(CustomerModel model)
        {
            var service = _serviceProvider.Provide<IEntityAddService<CustomerEntity, CustomerPropertyValueEntity>>();
            return service.Add(model);
        }
    }
}
