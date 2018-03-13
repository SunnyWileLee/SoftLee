using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories
{
    public class EntityPageQueryRepositoryProvider : IEntityPageQueryRepositoryProvider
    {
        private readonly IEntityPageQueryRepository[] _entityPageQueryRepositories;

        public EntityPageQueryRepositoryProvider(IEntityPageQueryRepository[] entityPageQueryRepositories)
        {
            _entityPageQueryRepositories = entityPageQueryRepositories;
        }

        public IEntityPageQueryRepository Provide()
        {
            return Provide(s => true);
        }

        public IEntityPageQueryRepository Provide(Func<IEntityPageQueryRepository, bool> selector)
        {
            return _entityPageQueryRepositories.First(selector);
        }
    }
}
