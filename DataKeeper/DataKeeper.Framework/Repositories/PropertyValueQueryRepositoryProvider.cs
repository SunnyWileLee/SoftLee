using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories
{
    public class PropertyValueQueryRepositoryProvider : IPropertyValueQueryRepositoryProvider
    {
        private readonly IPropertyValueQueryRepository[] _propertyValueQueryRepositories;

        public PropertyValueQueryRepositoryProvider(IPropertyValueQueryRepository[] propertyValueQueryRepositories)
        {
            _propertyValueQueryRepositories = propertyValueQueryRepositories;
        }

        public IPropertyValueQueryRepository Provide(Func<IPropertyValueQueryRepository, bool> selector)
        {
            return _propertyValueQueryRepositories.First(selector);
        }

        public IPropertyValueQueryRepository Provide()
        {
            return this.Provide(s => true);
        }
    }
}
