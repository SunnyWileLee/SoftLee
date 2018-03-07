using AutoBid.Cloud.Repositories.Price;
using AutoBid.Cloud.Repositories.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AutoBid.Cloud.Repositories
{
    class AutoBidDbContext : DbContext
    {
        public AutoBidDbContext()
            : base("AutoBidConnection")
        {

        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BidPriceEntity> BidPrices { get; set; }
    }
}