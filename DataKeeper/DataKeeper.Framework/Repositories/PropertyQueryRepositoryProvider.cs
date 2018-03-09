using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories
{
    public class PropertyQueryRepositoryProvider : IPropertyQueryRepositoryProvider
    {
        private readonly IPropertyQueryRepository[] _propertyQueryRepositories;

        public PropertyQueryRepositoryProvider(IPropertyQueryRepository[] propertyQueryRepositories)
        {
            _propertyQueryRepositories = propertyQueryRepositories;
        }

        public virtual IPropertyQueryRepository Provide()
        {
            return this.Provide(s => true);
        }

        public virtual IPropertyQueryRepository Provide(Func<IPropertyQueryRepository, bool> selector)
        {
            return _propertyQueryRepositories.First(selector);
        }
    }
}
