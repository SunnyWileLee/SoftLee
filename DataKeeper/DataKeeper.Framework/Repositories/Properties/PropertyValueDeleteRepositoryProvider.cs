using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories.Properties
{
    public class PropertyValueDeleteRepositoryProvider : IPropertyValueDeleteRepositoryProvider
    {
        private readonly IPropertyValueDeleteRepository[] _propertyValueDeleteRepositories;

        public PropertyValueDeleteRepositoryProvider(IPropertyValueDeleteRepository[] propertyValueDeleteRepositories)
        {
            _propertyValueDeleteRepositories = propertyValueDeleteRepositories;
        }

        public IPropertyValueDeleteRepository Provide(Func<IPropertyValueDeleteRepository, bool> selector)
        {
            return _propertyValueDeleteRepositories.First(selector);
        }

        public IPropertyValueDeleteRepository Provide()
        {
            return this.Provide(s => true);
        }
    }
}
