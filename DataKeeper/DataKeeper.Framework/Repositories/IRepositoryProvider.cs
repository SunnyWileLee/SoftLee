using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories
{
    public interface IRepositoryProvider<TRepository>
        where TRepository : IBaseRepository
    {
        TRepository Provide();
        TRepository Provide(Func<TRepository, bool> selector);
    }
}
