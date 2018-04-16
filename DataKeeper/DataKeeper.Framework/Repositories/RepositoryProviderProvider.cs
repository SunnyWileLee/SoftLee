using Autofac;
using DataKeeper.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories
{
    public class RepositoryProviderProvider : IRepositoryProviderProvider
    {
        public IRepositoryProvider<TRepository> Provide<TRepository>()
            where TRepository : IBaseRepository
        {
            return ObjectContainers.Current.Resolve<IRepositoryProvider<TRepository>>();
        }
    }
}
