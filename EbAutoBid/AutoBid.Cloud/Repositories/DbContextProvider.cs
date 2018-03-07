using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoBid.Cloud.Repositories
{
    class DbContextProvider : IDbContextProvider
    {
        public AutoBidDbContext Provide()
        {
            return new AutoBidDbContext { };
        }
    }
}