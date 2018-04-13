using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories.Properties
{
    public interface IPropertyQueryRepositoryProvider
    {
        IPropertyQueryRepository Provide();
        IPropertyQueryRepository Provide(Func<IPropertyQueryRepository, bool> selector);
    }
}
