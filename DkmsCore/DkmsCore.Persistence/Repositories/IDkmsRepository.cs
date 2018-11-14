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
        Task<List<TEntity>> GetList<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : DkmsEntity;
        Task<DkmsEntityPage<TEntity>> GetPage<TEntity>(Expression<Func<TEntity, bool>> predicate, DkmsEntityPageQuery query) where TEntity : DkmsEntity;
        Task<DkmsEntityPage<TEntity>> GetPage<TEntity, TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> order, DkmsEntityPageQuery query) where TEntity : DkmsEntity;
        Task<int> Count<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : DkmsEntity;
    }
}
