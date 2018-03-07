using AutoBid.Cloud.Applications.User;
using AutoBid.Cloud.Frameworks;
using AutoBid.Cloud.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AutoBid.Cloud.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserQueryService _userQueryService;
        private readonly IUserService _userService;

        [HttpGet, BidderAuthorize]
        public List<UserModel> GetUsers()
        {
            return _userQueryService.GetUser();
        }

        [HttpPost]
        public void AddUser(AddUserParas paras)
        {
            _userService.AddUser(paras);
        }

        [HttpPost]
        public void EditUser(EditUserParas paras)
        {
            _userService.UpdateUser(paras);
        }

        [HttpPost]
        public void DeleteUser(DeleteUserParas paras)
        {
            _userService.DeleteUser(paras.Id);
        }
    }
}