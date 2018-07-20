using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Thor.Repositories
{
    public interface IDkmsRepository
    {
        Task<Guid> AddEntity<TEntity>(TEntity entity) where TEntity : DkmsEntity;
        Task<int> Delete<TEntity>(Guid id) where TEntity : DkmsEntity;
        Task<List<TEntity>> GetList<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : DkmsEntity;
        Task<EntityPage<TEntity>> GetPage<TEntity>(Expression<Func<TEntity, bool>> predicate, EntityPageQuery query) where TEntity : DkmsEntity;
    }
}
