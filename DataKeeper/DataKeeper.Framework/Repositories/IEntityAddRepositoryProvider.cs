using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories
{
    public interface IEntityAddRepositoryProvider
    {
        IEntityAddRepository Provide();
        IEntityAddRepository Provide(Func<IEntityAddRepository, bool> selector);
    }
}
