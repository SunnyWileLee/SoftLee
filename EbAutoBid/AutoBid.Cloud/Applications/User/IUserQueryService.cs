using AutoBid.Cloud.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBid.Cloud.Applications.User
{
    public interface IUserQueryService
    {
        List<UserModel> GetUser();
    }
}
