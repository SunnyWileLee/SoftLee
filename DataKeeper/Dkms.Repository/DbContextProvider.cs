using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Repository
{
    class DbContextProvider : IDbContextProvider
    {
        private readonly IEfConnectionStringProvider _efConnectionStringProvider;

        public DbContextProvider(IEfConnectionStringProvider efConnectionStringProvider)
        {
            _efConnectionStringProvider = efConnectionStringProvider;
        }

        public string DbConnection { get; set; }

        public TDbContext Provide<TDbContext>()
            where TDbContext : DbContext
        {
            var type = typeof(TDbContext);
            var connection = string.IsNullOrEmpty(DbConnection) ? _efConnectionStringProvider.Provide() : DbConnection;
            return Activator.CreateInstance(type, connection) as TDbContext;
        }
    }
}
