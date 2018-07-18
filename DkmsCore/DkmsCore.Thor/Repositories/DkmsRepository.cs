using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Thor.Repositories
{
    public abstract class DkmsRepository : IDkmsRepository
    {
        private readonly DbContext _dbContext;

        protected DkmsRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<Guid> AddEntity<TEntity>(TEntity entity) where TEntity : DkmsEntity
        {
            _dbContext.Set<TEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public virtual async Task Delete<TEntity>(Guid id) where TEntity : DkmsEntity
        {
            var entity = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(s => s.Id == id);
            if (entity == null)
            {
                return;
            }
            _dbContext.Set<TEntity>().Remove(entity);
            var count = await _dbContext.SaveChangesAsync();
        }

        public virtual Task<List<TEntity>> GetList<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : DkmsEntity
        {
            throw new NotImplementedException();
        }

        public virtual Task<EntityPage<TEntity>> GetPage<TEntity>(Expression<Func<TEntity, bool>> predicate, EntityPageQuery query) where TEntity : DkmsEntity
        {
            throw new NotImplementedException();
        }
    }
}
