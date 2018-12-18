using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Persistence.Repositories
{
    public interface IDkmsUserRepository
    {
        DbContext DbContext { get; }
        IDkmsRepository DkmsRepository { get; }

        Task<Guid> AddAsync<TEntity>(Guid userId, TEntity entity) where TEntity : DkmsUserEntity;
        Task<DkmsPage<TEntity>> GetPageAsync<TEntity>(Guid userId, DkmsPageQuery query) where TEntity : DkmsUserEntity;
    }
}
