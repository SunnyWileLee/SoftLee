using AutoBid.Cloud.Applications.Price;
using AutoBid.Cloud.Frameworks;
using AutoBid.Cloud.Models.Price;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AutoBid.Cloud.Controllers
{
    public class PriceController : ApiController
    {
        private readonly IPriceService _priceService;
        private readonly IPriceQueryService _priceQueryService;

        public PriceController(IPriceService priceService, 
                               IPriceQueryService priceQueryService)
        {
            _priceService = priceService;
            _priceQueryService = priceQueryService;
        }

        [HttpPost, BidderAuthorize]
        public void SetPrice(BidPriceModel model)
        {
            _priceService.SetPrice(model);
        }

        [HttpGet, BidderAuthorize]
        public List<BidPriceModel> BidPrices(string sn)
        {
            return _priceQueryService.GetList(sn);
        }
    }
}