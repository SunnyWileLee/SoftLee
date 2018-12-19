using Dkms.Ums.Account.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dkms.Ums.Account.Domains.Logins
{
    public interface ILoginer
    {
        Task<string> LoginAsync(AccountEntity account);
    }
}
