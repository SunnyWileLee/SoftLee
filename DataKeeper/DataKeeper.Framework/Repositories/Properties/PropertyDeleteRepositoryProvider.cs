using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories.Properties
{
    public class PropertyDeleteRepositoryProvider : IPropertyDeleteRepositoryProvider
    {
        private readonly IPropertyDeleteRepository[] _propertyDeleteRepositories;

        public PropertyDeleteRepositoryProvider(IPropertyDeleteRepository[] propertyDeleteRepositories)
        {
            _propertyDeleteRepositories = propertyDeleteRepositories;
        }

        public IPropertyDeleteRepository Provide()
        {
            return this.Provide(s => true);
        }

        public IPropertyDeleteRepository Provide(Func<IPropertyDeleteRepository, bool> selector)
        {
            return _propertyDeleteRepositories.FirstOrDefault(selector);
        }
    }
}
