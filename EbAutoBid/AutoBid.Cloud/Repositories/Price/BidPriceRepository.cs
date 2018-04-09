using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoBid.Cloud.Repositories.Price
{
    class BidPriceRepository : IBidPriceRepository
    {
        private readonly IDbContextProvider _dbContextProvider;

        public BidPriceRepository(IDbContextProvider dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public void SetPrice(BidPriceEntity price)
        {
            using (var context = _dbContextProvider.Provide())
            {
                var entity = context.BidPrices.FirstOrDefault(s => s.UserId == price.UserId && s.Sn == price.Sn && s.IdResoTemp == price.IdResoTemp);
                if (entity == null)
                {
                    price.Id = Guid.NewGuid();
                    price.CreateTime = DateTime.Now;
                    context.BidPrices.Add(price);
                }
                else
                {
                    entity.MaxPrice = price.MaxPrice;
                }
                context.SaveChanges();
            }
        }
    }
}