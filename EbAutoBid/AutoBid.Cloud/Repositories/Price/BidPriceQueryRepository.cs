using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoBid.Cloud.Repositories.Price
{
    class BidPriceQueryRepository : IBidPriceQueryRepository
    {
        private readonly IDbContextProvider _dbContextProvider;

        public BidPriceQueryRepository(IDbContextProvider dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public List<BidPriceEntity> GetList(Guid userId, string sn)
        {
            using (var context = _dbContextProvider.Provide())
            {
                return context.BidPrices.Where(s => s.UserId == userId && s.Sn == sn).ToList();
            }
        }
    }
}