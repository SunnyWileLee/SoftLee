using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Persistence.Repositories
{
    public interface IDkmsRepository
    {
        DbContext DbContext { get; }

        Task<Guid> AddAsync<TEntity>(TEntity entity) where TEntity : DkmsEntity;
        Task<int> DeleteAsync<TEntity>(Guid id) where TEntity : DkmsEntity;
        Task<TEntity> FirstAsync<TEntity>(Guid id) where TEntity : DkmsEntity;
        Task<TEntity> FirstAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : DkmsEntity;
        Task<List<TEntity>> GetListAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : DkmsEntity;
        Task<DkmsPage<TEntity>> GetPageAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, DkmsPageQuery query) where TEntity : DkmsEntity;
        Task<DkmsPage<TEntity>> GetPageAsync<TEntity, TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> order, DkmsPageQuery query) where TEntity : DkmsEntity;
        Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : DkmsEntity;
    }
}
