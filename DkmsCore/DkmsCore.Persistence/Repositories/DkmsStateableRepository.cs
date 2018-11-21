using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Persistence.Repositories
{
    public class DkmsStateableRepository : DkmsRepository, IDkmsStateableRepository
    {
        public DkmsStateableRepository(IDbContextProvider dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<int> SetStateAsync<TEntity>(Guid userId, Guid id, DkmsEntityState state) where TEntity : DkmsStateableEntity
        {
            var entity = await FirstAsync<TEntity>(s => s.UserId == userId && s.Id == s.Id);
            if (entity == null)
            {
                return 0;
            }
            if (entity.State == state)
            {
                return 0;
            }
            entity.State = state;
            return await DbContext.SaveChangesAsync();
        }
    }
}
