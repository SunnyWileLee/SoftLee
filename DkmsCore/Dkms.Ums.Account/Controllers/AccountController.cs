using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dkms.Ums.Account.Domains.Logins;
using Dkms.Ums.Account.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dkms.Ums.Account.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILoginer _loginer;

        public AccountController(ILoginer loginer)
        {
            _loginer = loginer;
        }

        [HttpPost, Route("login")]
        public async Task<string> LoginAsync([FromBody]AccountEntity account)
        {
            return await _loginer.LoginAsync(account);
        }
    }
}