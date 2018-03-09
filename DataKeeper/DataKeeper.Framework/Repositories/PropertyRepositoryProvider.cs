using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories
{
    public class PropertyRepositoryProvider : IPropertyRepositoryProvider
    {
        private readonly IPropertyRepository[] _propertyRepositories;

        public PropertyRepositoryProvider(IPropertyRepository[] propertyRepositories)
        {
            _propertyRepositories = propertyRepositories;
        }

        public virtual IPropertyRepository Provide()
        {
            return Provide(s => true);
        }

        public virtual IPropertyRepository Provide(Func<IPropertyRepository, bool> selector)
        {
            return _propertyRepositories.First(selector);
        }
    }
}
