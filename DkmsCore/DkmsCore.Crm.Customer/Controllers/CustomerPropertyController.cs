using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DkmsCore.Crm.Customer.Repositories;
using DkmsCore.Infrustructure.Securitys;
using DkmsCore.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DkmsCore.Crm.Customer.Controllers
{
    [Route("crm/customer/property")]
    [ApiController]
    public class CustomerPropertyController : ControllerBase
    {
        private readonly IDkmsUserRepository _dkmsUserRepository;

        public CustomerPropertyController(IDkmsUserRepository dkmsUserRepository)
        {
            _dkmsUserRepository = dkmsUserRepository;
        }

        [HttpGet, Route("GetList")]
        public async Task<List<CustomerPropertyEntity>> GetListAsync()
        {
            return await _dkmsUserRepository.GetListAsync<CustomerPropertyEntity>(DkmsUserContext.UserIdDefaultEmpty);
        }

        [HttpPost, Route("Add")]
        public async Task<Guid> AddAsync(CustomerPropertyEntity entity)
        {
            return await _dkmsUserRepository.AddAsync(DkmsUserContext.UserIdDefaultEmpty, entity);
        }
    }
}