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
        private readonly IDkmsRepository _dkmsRepository;

        public DkmsPropertyRepository(IDkmsRepository dkmsRepository)
        {
            _dkmsRepository = dkmsRepository;
        }

        public async Task<Guid> AddAsync<TProperty>(Guid userId, TProperty property) where TProperty : DkmsPropertyEntity
        {
            property.UserId = userId;
            return await _dkmsRepository.AddAsync(property);
        }

        public async Task<int> DeleteAsync<TProperty>(Guid userId, Guid id) where TProperty : DkmsPropertyEntity
        {
            var property = await _dkmsRepository.FirstAsync<TProperty>(s => s.UserId == userId && s.Id == id);
            if (property == null)
            {
                return 0;
            }
            _dkmsRepository.DbContext.Set<TProperty>().Remove(property);
            return await _dkmsRepository.DbContext.SaveChangesAsync();
        }

        public async Task<List<TProperty>> GetListAsync<TProperty>(Guid userId) where TProperty : DkmsPropertyEntity
        {
            var list = await _dkmsRepository.GetListAsync<TProperty>(s => s.UserId == userId);
            return list;
        }
    }
}
