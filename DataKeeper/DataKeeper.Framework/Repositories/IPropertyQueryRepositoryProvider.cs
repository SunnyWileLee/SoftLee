using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories
{
    interface IPropertyQueryRepositoryProvider
    {
        IPropertyQueryRepository Provide();
        IPropertyQueryRepository Provide(Func<IPropertyQueryRepository, bool> selector);
    }
}
