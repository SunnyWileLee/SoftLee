using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories.Properties
{
    public interface IPropertyValueRepositoryProvider
    {
        IPropertyValueRepository Provide(Func<IPropertyValueRepository, bool> selector);
        IPropertyValueRepository Provide();
    }
}
