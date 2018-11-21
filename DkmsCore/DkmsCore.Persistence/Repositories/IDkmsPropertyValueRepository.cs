using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Persistence.Repositories
{
    public interface IDkmsPropertyValueRepository
    {
        Task<Guid> AddAsync<TPropertyValueEntity>(TPropertyValueEntity entity) where TPropertyValueEntity : DkmsPropertyValueEntity;
        Task<Guid> AddAsync<TPropertyValueEntity>(Guid userId, TPropertyValueEntity entity) where TPropertyValueEntity : DkmsPropertyValueEntity;
        Task<List<TPropertyValueEntity>> GetListAsync<TPropertyValueEntity>(Expression<Func<TPropertyValueEntity, bool>> predicate) where TPropertyValueEntity : DkmsPropertyValueEntity;
        Task<List<TPropertyValueEntity>> GetListAsync<TPropertyValueEntity>(Guid userId, Guid instanceId) where TPropertyValueEntity : DkmsPropertyValueEntity;
        Task<List<TPropertyValueEntity>> GetListAsync<TPropertyValueEntity>(Guid userId, IEnumerable<Guid> instanceIds) where TPropertyValueEntity : DkmsPropertyValueEntity;
    }
}
