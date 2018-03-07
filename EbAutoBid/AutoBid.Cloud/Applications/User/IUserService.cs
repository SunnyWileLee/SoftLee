using AutoBid.Cloud.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBid.Cloud.Applications.User
{
    public interface IUserService
    {
        void AddUser(AddUserParas paras);
        void UpdateUser(EditUserParas paras);
        void DeleteUser(Guid Id);
    }
}
