using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DkmsCore.Persistence.Repositories
{
    public class DkmsPropertyRepository : IDkmsPropertyRepository
    {
        public DkmsPropertyRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public DbContext DbContext { get; }

        public async Task<Guid> AddProperty<TProperty>(TProperty property) where TProperty : DkmsPropertyEntity
        {
            await DbContext.Set<TProperty>().AddAsync(property);
            await DbContext.SaveChangesAsync();
            return property.Id;
        }

        public async Task<int> Delete<TProperty>(Guid userId, Guid id) where TProperty : DkmsPropertyEntity
        {
            var property = await DbContext.Set<TProperty>().FirstOrDefaultAsync(s => s.UserId == userId && s.Id == id);
            if (property == null)
            {
                return 0;
            }
            DbContext.Set<TProperty>().Remove(property);
            return await DbContext.SaveChangesAsync();
        }

        public async Task<List<TProperty>> GetList<TProperty>(Guid userId) where TProperty : DkmsPropertyEntity
        {
            var list = await DbContext.Set<TProperty>().Where(s => s.UserId == userId).ToListAsync();
            return list;
        }
    }
}
