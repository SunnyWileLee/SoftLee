using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Repository
{
    public abstract class DkmsRepository : IDkmsRepository
    {
        private readonly IDbContextProvider _dbContextProvider;

        protected DkmsRepository(IDbContextProvider dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public IDbContextProvider ContextProvider
        {
            get
            {
                return _dbContextProvider;
            }
        }

        protected abstract DbContext CreateContext();

        protected virtual int Add<TEntity>(TEntity entity) where TEntity : DkmsEntity
        {
            using (var context = CreateContext())
            {
                var set = context.Set<TEntity>();
                set.Add(entity);
                return context.SaveChanges();
            }
        }

        protected virtual int Add<TEntity>(IEnumerable<TEntity> entities) where TEntity : DkmsEntity
        {
            using (var context = CreateContext())
            {
                var set = context.Set<TEntity>();
                set.AddRange(entities);
                return context.SaveChanges();
            }
        }

        protected virtual List<TEntity> QueryList<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : DkmsEntity
        {
            using (var context = CreateContext())
            {
                var set = context.Set<TEntity>();
                var list = set.Where(predicate).ToList();
                return list;
            }
        }

        protected virtual EntityPage<TEntity> QueryPage<TEntity>(Expression<Func<TEntity, bool>> predicate, int pageIndex, int pageSize) where TEntity : DkmsEntity
        {
            var skip = (pageIndex - 1) * pageSize;
            using (var context = CreateContext())
            {
                var set = context.Set<TEntity>();
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
