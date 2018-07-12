using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DkmsCore.Gamora.Models;
using DkmsCore.Gamora.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DkmsCore.Gamora.Controllers
{
    [Route("api/[controller]")]
    public class ServiceController : Controller
    {
        private readonly IDkmsApiRepository _dkmsApiRepository;

        public ServiceController(IDkmsApiRepository dkmsApiRepository)
        {
            _dkmsApiRepository = dkmsApiRepository;
        }

        [HttpGet]
        public async Task<List<DkmsApiModel>> Get(string service)
        {
            var apis = await _dkmsApiRepository.GetList(service);
            return apis;
        }
    }
}
