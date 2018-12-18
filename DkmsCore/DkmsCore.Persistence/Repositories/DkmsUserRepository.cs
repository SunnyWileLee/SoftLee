using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DkmsCore.Persistence.Repositories
{
    class DkmsUserRepository : IDkmsUserRepository
    {
        public DkmsUserRepository(IDkmsRepository dkmsRepository)
        {
            DkmsRepository = dkmsRepository;
        }

        public DbContext DbContext => DkmsRepository.DbContext;

        public IDkmsRepository DkmsRepository { get; }

        public async Task<Guid> AddAsync<TEntity>(Guid userId, TEntity entity) where TEntity : DkmsUserEntity
        {
            entity.UserId = userId;
            return await DkmsRepository.AddAsync(entity);
        }

        public async Task<DkmsPage<TEntity>> GetPageAsync<TEntity>(Guid userId, DkmsPageQuery query) where TEntity : DkmsUserEntity
        {
            return await DkmsRepository.GetPageAsync<TEntity>(s => s.UserId == userId, query);
        }
    }
}
