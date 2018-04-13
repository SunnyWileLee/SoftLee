using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories.Entities
{
    public class EntityAddRepositoryProvider : IEntityAddRepositoryProvider
    {
        private readonly IEntityAddRepository[] _entityAddRepositories;

        public EntityAddRepositoryProvider(IEntityAddRepository[] entityAddRepositories)
        {
            _entityAddRepositories = entityAddRepositories;
        }

        public IEntityAddRepository Provide()
        {
            return Provide(s => true);
        }

        public IEntityAddRepository Provide(Func<IEntityAddRepository, bool> selector)
        {
            return _entityAddRepositories.FirstOrDefault(selector);
        }
    }
}
