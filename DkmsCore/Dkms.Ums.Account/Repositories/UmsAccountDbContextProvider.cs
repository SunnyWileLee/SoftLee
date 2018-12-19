using DkmsCore.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dkms.Ums.Account.Repositories
{
    public class UmsAccountDbContextProvider : IDbContextProvider
    {
        private readonly UmsAccountDbContext _dbContext;

        public UmsAccountDbContextProvider(UmsAccountDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbContext Provide()
        {
            return _dbContext;
        }
    }
}
