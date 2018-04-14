using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories.Properties
{
    public interface IPropertyValueDeleteRepositoryProvider
    {
        IPropertyValueDeleteRepository Provide(Func<IPropertyValueDeleteRepository, bool> selector);
        IPropertyValueDeleteRepository Provide();
    }
}
