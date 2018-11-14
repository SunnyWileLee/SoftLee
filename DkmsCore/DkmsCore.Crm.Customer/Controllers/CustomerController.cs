using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DkmsCore.Crm.Customer.Models;
using DkmsCore.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DkmsCore.Crm.Customer.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        [HttpGet, Route("GetPage")]
        public DkmsPage<CustomerModel> GetPage()
        {
            return new DkmsPage<CustomerModel> { Count = 100 };
        }

    }
}
