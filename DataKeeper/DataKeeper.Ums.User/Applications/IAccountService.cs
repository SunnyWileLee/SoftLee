using DataKeeper.Ums.User.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Ums.User.Applications
{
    public interface IAccountService
    {
        Guid AddAccount(AccountModel model);
        Guid Signin(AccountModel model);
    }
}
