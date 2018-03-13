using DataKeeper.Framework.Models;
using DataKeeper.Ums.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Ums.User.Repositories
{
    interface IAccountQueryRepository
    {
        AccountEntity GetByPhone(string phone);
        AccountEntity GetById(Guid id);
        PageCollection<AccountEntity> Page(Expression<Func<AccountEntity, bool>> predicate, PageQueryParas paras);
    }
}
