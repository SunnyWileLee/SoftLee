using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Persistence.Repositories
{
    public interface IDkmsStateableRepository: IDkmsRepository
    {
        Task<int> SetStateAsync<TEntity>(Guid userId,Guid id, DkmsEntityState state) where TEntity : DkmsStateableEntity;
    }
}
