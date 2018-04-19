using DataKeeper.Crm.Customer.Applications;
using DataKeeper.Crm.Customer.Entities;
using DataKeeper.Crm.Customer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataKeeper.Cloud.Controllers.Crm
{
    public class CustomerPropertyController : AuthorizeController
    {
        private readonly ICustomerPropertyService _customerPropertyService;

        public CustomerPropertyController(ICustomerPropertyService customerPropertyService)
        {
            _customerPropertyService = customerPropertyService;
        }

        [HttpGet]
        public List<CustomerPropertyEntity> List()
        {
            return _customerPropertyService.GetList();
        }

        [HttpPost]
        public Guid Add(CustomerPropertyEntity model)
        {
            return _customerPropertyService.Add(model);
        }
    }
}