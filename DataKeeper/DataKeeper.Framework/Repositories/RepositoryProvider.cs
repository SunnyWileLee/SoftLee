using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories
{
    public class RepositoryProvider<TRepository> : IRepositoryProvider<TRepository>
        where TRepository : IBaseRepository
    {
        private readonly TRepository[] _repositories;

        public RepositoryProvider(TRepository[] repositories)
        {
            _repositories = repositories;
        }

        public TRepository Provide()
        {
            return this.Provide(s => true);
        }

        public TRepository Provide(Func<TRepository, bool> selector)
        {
            return _repositories.First(selector);
        }
    }
}
