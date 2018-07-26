using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Thor.Repositories
{
    public class DkmsRepository : IDkmsRepository
    {
        private readonly DbContext _dbContext;

        public DkmsRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbContext DbContext
        {
            get
            {
                return _dbContext;
            }
        }

        public virtual async Task<Guid> AddEntity<TEntity>(TEntity entity) where TEntity : DkmsEntity
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public virtual async Task<int> Delete<TEntity>(Guid id) where TEntity : DkmsEntity
        {
            var entity = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(s => s.Id == id);
            if (entity == null)
            {
                return 0;
            }
            _dbContext.Set<TEntity>().Remove(entity);
            var count = await _dbContext.SaveChangesAsync();
            return count;
        }

        public virtual async Task<List<TEntity>> GetList<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : DkmsEntity
        {
            var list = _dbContext.Set<TEntity>().Where(predicate);
            return await list.ToListAsync();
        }

        public virtual async Task<EntityPage<TEntity>> GetPage<TEntity>(Expression<Func<TEntity, bool>> predicate, EntityPageQuery query) where TEntity : DkmsEntity
        {
            var page = await _dbContext.Set<TEntity>().Where(predicate).OrderByDescending(s => s.CreateTime).Skip(query.Skip).Take(query.Take).ToListAsync();
            var count = await _dbContext.Set<TEntity>().CountAsync();
            return new EntityPage<TEntity>
            {
                PageSize = query.PageSize,
                Count = count,
                List = page,
                PageIndex = query.PageIndex
            };
        }
    }
}
