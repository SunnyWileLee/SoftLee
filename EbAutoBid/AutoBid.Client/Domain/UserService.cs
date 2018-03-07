using AutoBid.Client.Models;
using AutoBid.Client.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBid.Client.Domain
{
    class UserService
    {
        public UserModel GetByUserId(string userId)
        {
            ApiHttpExecutor executor = new ApiHttpExecutor();
            var url = $"{ApiHttpExecutor.ApiDomian}/User/GetUserById?userId={userId}";
            var user = executor.Get<UserModel>(url);
            return user;
        }

        public List<UserModel> GetUsers()
        {
            ApiHttpExecutor executor = new ApiHttpExecutor();
            var url = $"{ApiHttpExecutor.ApiDomian}/User/GetUsers";
            var users = executor.Get<List<UserModel>>(url);
            return users;
        }
    }
}
