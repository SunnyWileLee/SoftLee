using DkmsCore.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DkmsCore.Oms.Order.Repositories
{
    public class OmsOrderDbContextProvider : IDbContextProvider
    {
        private readonly OmsOrderDbContext _omsOrdersDbContext;

        public OmsOrderDbContextProvider(OmsOrderDbContext omsOrdersDbContext)
        {
            _omsOrdersDbContext = omsOrdersDbContext;
        }

        public DbContext Provide()
        {
            return _omsOrdersDbContext;
        }
    }
}
