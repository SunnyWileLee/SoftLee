using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Thor.Repositories
{
    public interface IDkmsPropertyValueRepository
    {
        Task<Guid> AddPropertyValueEntity<TPropertyValueEntity>(TPropertyValueEntity entity) where TPropertyValueEntity : DkmsPropertyValueEntity;
        Task<List<TPropertyValueEntity>> GetList<TPropertyValueEntity>(Expression<Func<TPropertyValueEntity, bool>> predicate) where TPropertyValueEntity : DkmsPropertyValueEntity;
        Task<List<TPropertyValueEntity>> GetList<TPropertyValueEntity>(Guid userId, Guid instanceId) where TPropertyValueEntity : DkmsPropertyValueEntity;
        Task<List<TPropertyValueEntity>> GetList<TPropertyValueEntity>(Guid userId, IEnumerable<Guid> instanceIds) where TPropertyValueEntity : DkmsPropertyValueEntity;
    }
}
