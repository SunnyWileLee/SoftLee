using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKeeper.Ums.User.Entities;

namespace DataKeeper.Ums.User.Repositories
{
    class AccountRepository : IAccountRepository
    {
        private readonly IUserContextProvider _userContextProvider;

        public AccountRepository(IUserContextProvider userContextProvider)
        {
            _userContextProvider = userContextProvider;
        }

        public Guid AddAccount(AccountEntity account)
        {
            using (var context = _userContextProvider.Provide())
            {
                var accounts = context.Set<AccountEntity>();
                accounts.Add(account);
                return context.SaveChanges() > 0 ? account.Id : Guid.Empty;
            }
        }
    }
}
