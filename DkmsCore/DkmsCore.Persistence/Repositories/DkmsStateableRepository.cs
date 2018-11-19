using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Persistence.Repositories
{
    public class DkmsStateableRepository : IDkmsStateableRepository
    {
        public DkmsStateableRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public DbContext DbContext { get; }

        public async Task<int> SetState<TEntity>(Guid id, DkmsEntityState state) where TEntity : DkmsStateableEntity
        {
            throw new NotImplementedException();
        }
    }
}
