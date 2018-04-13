using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories.Entities
{
    public class EntityQueryRepositoryProvider : IEntityQueryRepositoryProvider
    {
        private readonly IEntityQueryRepository[] _entityPageQueryRepositories;

        public EntityQueryRepositoryProvider(IEntityQueryRepository[] entityPageQueryRepositories)
        {
            _entityPageQueryRepositories = entityPageQueryRepositories;
        }

        public IEntityQueryRepository Provide()
        {
            return Provide(s => true);
        }

        public IEntityQueryRepository Provide(Func<IEntityQueryRepository, bool> selector)
        {
            return _entityPageQueryRepositories.First(selector);
        }
    }
}
