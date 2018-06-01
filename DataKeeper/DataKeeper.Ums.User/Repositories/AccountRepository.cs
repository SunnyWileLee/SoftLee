using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataKeeper.Ums.User.Entities;
using Dkms.Repository;

namespace DataKeeper.Ums.User.Repositories
{
    class AccountRepository : IAccountRepository
    {
        private readonly IDbContextProvider _contextProvider;

        public AccountRepository(IDbContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }

        public Guid AddAccount(AccountEntity account)
        {
            using (var context = _contextProvider.Provide<UserDbContext>())
            {
                var accounts = context.Set<AccountEntity>();
                accounts.Add(account);
                return context.SaveChanges() > 0 ? account.Id : Guid.Empty;
            }
        }
    }
}
