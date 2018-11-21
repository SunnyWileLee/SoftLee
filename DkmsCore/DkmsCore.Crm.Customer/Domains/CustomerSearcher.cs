using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DkmsCore.Crm.Customer.Models;
using DkmsCore.Crm.Customer.Repositories;
using DkmsCore.Infrustructure.Securitys;
using DkmsCore.Persistence;
using DkmsCore.Persistence.Repositories;

namespace DkmsCore.Crm.Customer.Domains
{
    public class CustomerSearcher : ICustomerSearcher
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IDkmsPropertyValueRepository _dkmsPropertyValueRepository;

        public CustomerSearcher(ICustomerRepository customerRepository, IDkmsPropertyValueRepository dkmsPropertyValueRepository)
        {
            _customerRepository = customerRepository;
            _dkmsPropertyValueRepository = dkmsPropertyValueRepository;
        }

        public async Task<DkmsPage<CustomerModel>> GetPageAsync(CustomerPageQuery query)
        {
            var page = await _customerRepository.GetPageAsync(s => s.UserId == DkmsUserContext.UserIdDefaultEmpty, query);
            if (!page.Any())
            {
                return DkmsPage<CustomerModel>.Empty(query);
            }
            var userId = DkmsUserContext.UserIdDefaultEmpty;
            var customerIds = page.GetKeys(s => s.Id);
            var values = await _dkmsPropertyValueRepository.GetListAsync<CustomerPropertyValueEntity>(userId, customerIds);
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
