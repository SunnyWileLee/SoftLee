using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Persistence.Repositories
{
    public class DkmsRepository : IDkmsRepository
    {
        public DkmsRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public DbContext DbContext { get; }

        public virtual async Task<Guid> AddAsync<TEntity>(TEntity entity) where TEntity : DkmsEntity
        {
            await DbContext.Set<TEntity>().AddAsync(entity);
            await DbContext.SaveChangesAsync();
            return entity.Id;
        }

        public virtual async Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : DkmsEntity
        {
            var count = await DbContext.Set<TEntity>().CountAsync();
            return count;
        }

        public virtual async Task<int> DeleteAsync<TEntity>(Guid id) where TEntity : DkmsEntity
        {
            var entity = await DbContext.Set<TEntity>().FirstOrDefaultAsync(s => s.Id == id);
            if (entity == null)
            {
                return 0;
            }
            DbContext.Set<TEntity>().Remove(entity);
            var count = await DbContext.SaveChangesAsync();
            return count;
        }

        public async Task<TEntity> FirstAsync<TEntity>(Guid id) where TEntity : DkmsEntity
        {
            return await FirstAsync<TEntity>(s => s.Id == id);
        }

        public async Task<TEntity> FirstAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : DkmsEntity
        {
            return await DbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<List<TEntity>> GetListAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : DkmsEntity
        {
            var list = DbContext.Set<TEntity>().Where(predicate);
            return await list.ToListAsync();
        }

        public virtual async Task<DkmsPage<TEntity>> GetPageAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, DkmsPageQuery query) where TEntity : DkmsEntity
        {
            return await GetPageAsync(predicate, s => s.CreateTime, query);
        }

        public virtual async Task<DkmsPage<TEntity>> GetPageAsync<TEntity, TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> order, DkmsPageQuery query) where TEntity : DkmsEntity
        {
            var page = await DbContext.Set<TEntity>().Where(predicate).OrderByDescending(order).Skip(query.Skip).Take(query.Take).ToListAsync();
            var count = await CountAsync(predicate);
            return new DkmsPage<TEntity>
            {
                PageSize = query.PageSize,
                Count = count,
                List = page,
                PageIndex = query.PageIndex
            };
        }
    }
}
