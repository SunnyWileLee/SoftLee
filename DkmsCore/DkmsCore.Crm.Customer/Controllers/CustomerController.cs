using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DkmsCore.Crm.Customer.Domains;
using DkmsCore.Crm.Customer.Models;
using DkmsCore.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DkmsCore.Crm.Customer.Controllers
{
    [Route("crm/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerSearcher _customerSearcher;
        private readonly ICustomerKeeper _customerKeeper;

        public CustomerController(ICustomerSearcher customerSearcher, ICustomerKeeper customerKeeper)
        {
            _customerSearcher = customerSearcher;
            _customerKeeper = customerKeeper;
        }

        [HttpGet, Route("GetPage")]
        public async Task<DkmsPage<CustomerModel>> GetPageAsync([FromQuery]CustomerPageQuery query)
        {
            return await _customerSearcher.GetPageAsync(query);
        }

        [HttpPost, Route("Add")]
        public async Task<Guid> AddAsync([FromBody]CustomerModel model)
        {
            return await _customerKeeper.AddAsync(model);
        }
    }
}
