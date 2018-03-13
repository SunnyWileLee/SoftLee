using DataKeeper.Ums.User.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Ums.User.Repositories
{
    class UserContext : DbContext
    {
        public UserContext(string name)
            : base(name)
        {

        }


        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<TokenEntity> Tokens { get; set; }
    }
}
