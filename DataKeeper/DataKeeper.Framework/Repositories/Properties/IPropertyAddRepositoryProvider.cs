using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories.Properties
{
    public interface IPropertyAddRepositoryProvider
    {
        IPropertyAddRepository Provide();
        IPropertyAddRepository Provide(Func<IPropertyAddRepository, bool> selector);
    }
}
