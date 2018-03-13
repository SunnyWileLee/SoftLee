using DataKeeper.Ums.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Ums.User.Repositories
{
    interface IAccountRepository
    {
        Guid AddAccount(AccountEntity account);
    }
}
