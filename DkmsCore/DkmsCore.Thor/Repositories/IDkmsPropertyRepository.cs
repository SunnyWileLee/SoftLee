using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Thor.Repositories
{
    public interface IDkmsPropertyRepository
    {
        Task<Guid> AddProperty<TProperty>(TProperty property) where TProperty : DkmsPropertyEntity;
        Task<List<TProperty>> GetList<TProperty>(Guid userId) where TProperty : DkmsPropertyEntity;
        Task<int> Delete<TProperty>(Guid userId, Guid id) where TProperty : DkmsPropertyEntity;
    }
}
