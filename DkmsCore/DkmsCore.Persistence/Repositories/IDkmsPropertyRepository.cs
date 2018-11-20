using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Persistence.Repositories
{
    public interface IDkmsPropertyRepository
    {
        Task<Guid> AddAsync<TProperty>(Guid userId, TProperty property) where TProperty : DkmsPropertyEntity;
        Task<List<TProperty>> GetListAsync<TProperty>(Guid userId) where TProperty : DkmsPropertyEntity;
        Task<int> DeleteAsync<TProperty>(Guid userId, Guid id) where TProperty : DkmsPropertyEntity;
    }
}
