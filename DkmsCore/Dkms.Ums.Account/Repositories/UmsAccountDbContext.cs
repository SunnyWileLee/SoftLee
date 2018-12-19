using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dkms.Ums.Account.Repositories
{
    public class UmsAccountDbContext : DbContext
    {
        public UmsAccountDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AccountEntity> Accounts { get; set; }
    }
}
