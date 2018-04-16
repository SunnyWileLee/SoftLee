using DataKeeper.Crm.Customer.Applications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataKeeper.Cloud.Controllers.Crm
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerQueryService _customerQueryService;

        public CustomerController(ICustomerQueryService customerQueryService)
        {
            _customerQueryService = customerQueryService;
        }
    }
}