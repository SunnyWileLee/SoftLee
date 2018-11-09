using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Thor.Repositories
{
    public abstract class DkmsPropertyValueRepository : IDkmsPropertyValueRepository
    {
        public DkmsPropertyValueRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public DbContext DbContext { get; }

        public virtual async Task<Guid> AddPropertyValueEntity<TPropertyValueEntity>(TPropertyValueEntity entity) where TPropertyValueEntity : DkmsPropertyValueEntity
        {
            await DbContext.Set<TPropertyValueEntity>().AddAsync(entity);
            await DbContext.SaveChangesAsync();
            return entity.Id;
        }

        public virtual async Task<List<TPropertyValueEntity>> GetList<TPropertyValueEntity>(Expression<Func<TPropertyValueEntity, bool>> predicate) where TPropertyValueEntity : DkmsPropertyValueEntity
        {
            var list = DbContext.Set<TPropertyValueEntity>().Where(predicate);
            return await list.ToListAsync();
        }

        public virtual async Task<List<TPropertyValueEntity>> GetList<TPropertyValueEntity>(Guid userId, Guid instanceId) where TPropertyValueEntity : DkmsPropertyValueEntity
        {
            return await GetList<TPropertyValueEntity>(s => s.UserId == userId && s.InstanceId == instanceId);
        }

        public virtual async Task<List<TPropertyValueEntity>> GetList<TPropertyValueEntity>(Guid userId, IEnumerable<Guid> instanceIds) where TPropertyValueEntity : DkmsPropertyValueEntity
        {
            return await GetList<TPropertyValueEntity>(s => s.UserId == userId && instanceIds.Contains(s.InstanceId));
        }
    }
}
