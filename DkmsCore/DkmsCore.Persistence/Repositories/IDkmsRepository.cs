using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Persistence.Repositories
{
    public interface IDkmsRepository
    {
        Task<Guid> AddEntity<TEntity>(TEntity entity) where TEntity : DkmsEntity;
        Task<int> Delete<TEntity>(Guid id) where TEntity : DkmsEntity;
        Task<TEntity> Get<TEntity>(Guid id) where TEntity : DkmsEntity;
        Task<List<TEntity>> GetList<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : DkmsEntity;
        Task<DkmsPage<TEntity>> GetPage<TEntity>(Expression<Func<TEntity, bool>> predicate, DkmsPageQuery query) where TEntity : DkmsEntity;
        Task<DkmsPage<TEntity>> GetPage<TEntity, TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> order, DkmsPageQuery query) where TEntity : DkmsEntity;
        Task<int> Count<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : DkmsEntity;
    }
}
