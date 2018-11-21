using DkmsCore.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Gms.Goods.Repositories
{
    public class GmsGoodsDbContextProvider : IDbContextProvider
    {
        private readonly GmsGoodsDbContext _gmsGoodsDbContext;

        public GmsGoodsDbContextProvider(GmsGoodsDbContext gmsGoodsDbContext)
        {
            _gmsGoodsDbContext = gmsGoodsDbContext;
        }

        public DbContext Provide()
        {
            return _gmsGoodsDbContext;
        }
    }
}
