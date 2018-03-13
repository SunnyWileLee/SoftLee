using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Ums.User.Repositories
{
    class UserContextProvider : IUserContextProvider
    {
        public DbContext Provide()
        {
            return new UserContext("DataKeeperConnection");
        }
    }
}
