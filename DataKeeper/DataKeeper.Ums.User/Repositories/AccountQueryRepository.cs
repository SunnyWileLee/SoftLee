using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataKeeper.Framework.Models;
using DataKeeper.Ums.User.Entities;

namespace DataKeeper.Ums.User.Repositories
{
    class AccountQueryRepository : IAccountQueryRepository
    {
        public AccountEntity GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public AccountEntity GetByPhone(string phone)
        {
            throw new NotImplementedException();
        }

        public PageCollection<AccountEntity> Page(Expression<Func<AccountEntity, bool>> predicate, PageQueryParas paras)
        {
            throw new NotImplementedException();
        }
    }
}
