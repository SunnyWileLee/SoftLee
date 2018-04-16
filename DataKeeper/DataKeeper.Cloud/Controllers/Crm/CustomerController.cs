using DataKeeper.Crm.Customer.Applications;
using DataKeeper.Crm.Customer.Models;
using DataKeeper.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataKeeper.Cloud.Controllers.Crm
{
    public class CustomerController : AuthorizeController
    {
        private readonly ICustomerQueryService _customerQueryService;
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerQueryService customerQueryService,
                                  ICustomerService customerService)
        {
            _customerQueryService = customerQueryService;
            _customerService = customerService;
        }

        [HttpGet]
        public PageCollection<CustomerModel> Page([FromUri]CustomerQueryParameter parameter)
        {
            var data = _customerQueryService.Page<CustomerModel>(parameter);
            return data;
        }

        [HttpPost]
        public Guid Add(CustomerModel model)
        {
            var id = _customerService.Add(model);
            return id;
        }
    }
}