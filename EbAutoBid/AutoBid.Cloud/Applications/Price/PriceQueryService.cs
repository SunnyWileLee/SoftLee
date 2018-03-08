using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoBid.Cloud.Frameworks;
using AutoBid.Cloud.Models.Price;
using AutoBid.Cloud.Repositories.Price;
using AutoMapper;

namespace AutoBid.Cloud.Applications.Price
{
    class PriceQueryService : IPriceQueryService
    {
        private readonly IBidPriceQueryRepository _bidPriceQueryRepository;

        public PriceQueryService(IBidPriceQueryRepository bidPriceQueryRepository)
        {
            _bidPriceQueryRepository = bidPriceQueryRepository;
        }

        public List<BidPriceModel> GetList(string sn)
        {
            var userId = BidderContext.Current.UserId;
            var prices = _bidPriceQueryRepository.GetList(userId, sn);
            return Mapper.Map<List<BidPriceModel>>(prices);
        }
    }
}