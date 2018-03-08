using AutoBid.Cloud.Frameworks;
using AutoBid.Cloud.Models.Price;
using AutoBid.Cloud.Repositories.Price;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoBid.Cloud.Applications.Price
{
    class PriceService : IPriceService
    {
        private readonly IBidPriceRepository _bidPriceRepository;

        public PriceService(IBidPriceRepository bidPriceRepository)
        {
            _bidPriceRepository = bidPriceRepository;
        }

        public void SetPrice(BidPriceModel model)
        {
            var price = Mapper.Map<BidPriceEntity>(model);
            price.UserId = BidderContext.Current.UserId;
            _bidPriceRepository.SetPrice(price);
        }
    }
}