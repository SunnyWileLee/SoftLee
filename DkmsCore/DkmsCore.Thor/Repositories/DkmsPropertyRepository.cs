using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DkmsCore.Thor.Repositories
{
    public class DkmsPropertyRepository : IDkmsPropertyRepository
    {
        private readonly DbContext _dbContext;

        public DkmsPropertyRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbContext DbContext
        {
            get
            {
                return _dbContext;
            }
        }

        public async Task<Guid> AddProperty<TProperty>(TProperty property) where TProperty : DkmsPropertyEntity
        {
            await _dbContext.Set<TProperty>().AddAsync(property);
            await _dbContext.SaveChangesAsync();
            return property.Id;
        }

        public async Task<int> Delete<TProperty>(Guid userId, Guid id) where TProperty : DkmsPropertyEntity
        {
            var property = await _dbContext.Set<TProperty>().FirstOrDefaultAsync(s => s.UserId == userId && s.Id == id);
            if (property == null)
            {
                return 0;
            }
            _dbContext.Set<TProperty>().Remove(property);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<TProperty>> GetList<TProperty>(Guid userId) where TProperty : DkmsPropertyEntity
        {
            var list = await _dbContext.Set<TProperty>().Where(s => s.UserId == userId).ToListAsync();
            return list;
        }
    }
}
