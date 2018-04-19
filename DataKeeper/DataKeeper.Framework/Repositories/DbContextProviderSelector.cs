using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataKeeper.Framework.Entities;
using DataKeeper.Infrustructure;

namespace DataKeeper.Framework.Repositories
{
    public class DbContextProviderSelector : IDbContextProviderSelector
    {
        private readonly IDbContextProvider[] _dbContextProviders;

        public DbContextProviderSelector(IDbContextProvider[] dbContextProviders)
        {
            _dbContextProviders = dbContextProviders;
        }

        public IDbContextProvider Select<TEntity>() where TEntity : UserEntity
        {
            var type = typeof(TEntity);
            var scopeAttr = type.GetCustomAttribute<ScopeEntityAttribute>(true);
            if (scopeAttr == null)
            {
                throw new ArgumentOutOfRangeException(type.FullName);
            }
            var scope = scopeAttr.Scope;
            return _dbContextProviders.First(s => s.Scope == scope);
        }
    }
}
