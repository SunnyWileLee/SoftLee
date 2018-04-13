using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories.Properties
{
    public class PropertyAddRepositoryProvider : IPropertyAddRepositoryProvider
    {
        private readonly IPropertyAddRepository[] _propertyRepositories;

        public PropertyAddRepositoryProvider(IPropertyAddRepository[] propertyRepositories)
        {
            _propertyRepositories = propertyRepositories;
        }

        public virtual IPropertyAddRepository Provide()
        {
            return Provide(s => true);
        }

        public virtual IPropertyAddRepository Provide(Func<IPropertyAddRepository, bool> selector)
        {
            return _propertyRepositories.First(selector);
        }
    }
}
