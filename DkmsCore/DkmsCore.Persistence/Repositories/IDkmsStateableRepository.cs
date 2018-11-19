using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Persistence.Repositories
{
    public interface IDkmsStateableRepository
    {
        Task<int> SetState<TEntity>(Guid id, DkmsEntityState state) where TEntity : DkmsStateableEntity;
    }
}
