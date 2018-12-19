using Dkms.Ums.Account.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dkms.Ums.Account.Domains.Tokens
{
    public interface IPasswordFactory
    {
        string CreatePassword(string password, out string salt);
        bool VerifyPassword(AccountEntity account, string password);
    }
}
