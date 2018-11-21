using DkmsCore.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Gms.Stock.Repositories
{
    public class GmsStockDbContextProvider : IDbContextProvider
    {
        private readonly GmsStockDbContext _gmsStockDbContext;

        public GmsStockDbContextProvider(GmsStockDbContext gmsStockDbContext)
        {
            _gmsStockDbContext = gmsStockDbContext;
        }

        public DbContext Provide()
        {
            return _gmsStockDbContext;
        }
    }
}
