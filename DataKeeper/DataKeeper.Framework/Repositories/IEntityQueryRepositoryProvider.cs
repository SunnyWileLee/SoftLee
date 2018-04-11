using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories
{
    public interface IEntityQueryRepositoryProvider
    {
        IEntityQueryRepository Provide();
        IEntityQueryRepository Provide(Func<IEntityQueryRepository, bool> selector);
    }
}
