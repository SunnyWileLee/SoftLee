using Dkms.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Business.Base.Entity
{
    public abstract class UserEntityRepository : DkmsRepository
    {
        protected UserEntityRepository(IDbContextProvider dbContextProvider) : base(dbContextProvider)
        {

        }

        protected virtual List<TEntity> QueryList<TEntity>(Guid userId, Expression<Func<TEntity, bool>> predicate) where TEntity : UserEntity
        {
            using (var context = CreateContext())
            {
                var set = context.Set<TEntity>().Where(s => s.UserId == userId);
                var list = set.Where(predicate).ToList();
                return list;
            }
        }

        protected virtual EntityPage<TEntity> QueryPage<TEntity>(Guid userId, Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize) where TEntity : UserEntity
        {
            var skip = (pageIndex - 1) * pageSize;
            using (var context = CreateContext())
            {
                var set = context.Set<TEntity>().Where(s => s.UserId == userId);
                var list = set.Where(predicate).OrderByDescending(s => s.CreateTime).Skip(skip).Take(pageSize).ToList();
                var count = set.Count(predicate);
                return new EntityPage<TEntity>
                {
                    PageSize = pageSize,
                    Count = count,
                    List = list,
                    PageIndex = pageIndex
                };
            }
        }
    }
}
