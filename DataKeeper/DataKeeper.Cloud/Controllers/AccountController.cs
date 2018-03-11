using DataKeeper.Framework.Models;
using DataKeeper.Ums.User.Applications;
using DataKeeper.Ums.User.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataKeeper.Cloud.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAccountQueryService _accountQueryService;
        private readonly IAccountService _accountService;

        public AccountController(IAccountQueryService accountQueryService,
                                 IAccountService accountService)
        {
            _accountQueryService = accountQueryService;
            _accountService = accountService;
        }

        [HttpGet]
        public PageCollection<AccountModel> AccountPage(AccountPageQueryParas paras)
        {
            return _accountQueryService.Page(paras);
        }

        [HttpPost]
        public Guid Add(AccountModel model)
        {
            return _accountService.AddAccount(model);
        }
    }
}