using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories.Properties
{
    class PropertyValueSetRepositoryProvider : IPropertyValueSetRepositoryProvider
    {
        private readonly IPropertyValueSetRepository[] _propertyValueRepositories;

        public PropertyValueSetRepositoryProvider(IPropertyValueSetRepository[] propertyValueRepositories)
        {
            _propertyValueRepositories = propertyValueRepositories;
        }

        public virtual IPropertyValueSetRepository Provide(Func<IPropertyValueSetRepository, bool> selector)
        {
            return _propertyValueRepositories.First(selector);
        }

        public virtual IPropertyValueSetRepository Provide()
        {
            return this.Provide(s => true);
        }
    }
}
