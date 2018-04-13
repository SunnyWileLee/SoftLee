using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories.Properties
{
    interface IPropertyValueQueryRepositoryProvider
    {
        IPropertyValueQueryRepository Provide(Func<IPropertyValueQueryRepository, bool> selector);
        IPropertyValueQueryRepository Provide();
    }
}
