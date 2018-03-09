using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories
{
    class PropertyValueRepositoryProvider : IPropertyValueRepositoryProvider
    {
        private readonly IPropertyValueRepository[] _propertyValueRepositories;

        public PropertyValueRepositoryProvider(IPropertyValueRepository[] propertyValueRepositories)
        {
            _propertyValueRepositories = propertyValueRepositories;
        }

        public virtual IPropertyValueRepository Provide(Func<IPropertyValueRepository, bool> selector)
        {
            return _propertyValueRepositories.First(selector);
        }

        public virtual IPropertyValueRepository Provide()
        {
            return this.Provide(s => true);
        }
    }
}
