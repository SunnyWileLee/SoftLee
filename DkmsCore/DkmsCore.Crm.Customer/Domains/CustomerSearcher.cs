using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DkmsCore.Crm.Customer.Models;
using DkmsCore.Crm.Customer.Repositories;
using DkmsCore.Infrustructure.Securitys;
using DkmsCore.Persistence;

namespace DkmsCore.Crm.Customer.Domains
{
    public class CustomerSearcher : ICustomerSearcher
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerPropertyValueRepository _customerPropertyValueRepository;

        public CustomerSearcher(ICustomerRepository customerRepository, ICustomerPropertyValueRepository customerPropertyValueRepository)
        {
            _customerRepository = customerRepository;
            _customerPropertyValueRepository = customerPropertyValueRepository;
        }

        public async Task<DkmsPage<CustomerModel>> GetPage(CustomerPageQuery query)
        {
            var page = await _customerRepository.GetPage(s => s.UserId == DkmsUserContext.UserIdDefaultEmpty, query);
            if (!page.Any())
            {
                return DkmsPage<CustomerModel>.Empty(query);
            }
            var userId = DkmsUserContext.UserIdDefaultEmpty;
            var customerIds = page.GetKeys(s => s.Id);
            var values = await _customerPropertyValueRepository.GetList(userId, customerIds);
            var customers = page.List.Select(customer =>
            {
                var model = new CustomerModel
                {
                    Customer = customer
                };
                model.Values = values.Where(v => v.InstanceId == customer.Id).ToList();
                return model;
            }).ToList();
            return new DkmsPage<CustomerModel>()
            {
                Count = page.Count,
                List = customers,
                PageSize = page.PageSize,
                PageIndex = page.PageIndex
            };
        }
    }
}
