using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataKeeper.Framework.Models;
using DataKeeper.Ums.User.Entities;
using Dkms.Repository;

namespace DataKeeper.Ums.User.Repositories
{
    class AccountQueryRepository : IAccountQueryRepository
    {
        private readonly IDbContextProvider _contextProvider;

        public AccountQueryRepository(IDbContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }

        public AccountEntity GetById(Guid id)
        {
            using (var context = _contextProvider.Provide<UserDbContext>())
            {
                var users = context.Set<AccountEntity>();
                return users.FirstOrDefault(s => s.Id == id);
            }
        }

        public AccountEntity GetByPhone(string phone)
        {
            throw new NotImplementedException();
        }

        public PageCollection<AccountEntity> Page(Expression<Func<AccountEntity, bool>> predicate, PageQueryParameter<AccountEntity> paras)
        {
            throw new NotImplementedException();
        }
    }
}
