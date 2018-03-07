using AutoBid.Client.Models;
using AutoBid.Client.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBid.Client.Domain
{
    class BidPriceService
    {
        private static List<BidPriceModel> prices = null;
        private static object priceLock = new object { };
        private readonly ApiHttpExecutor executor = new ApiHttpExecutor();
        private readonly PriceSnProvider snProvider = new PriceSnProvider { };

        public List<BidPriceModel> GetPrices()
        {
            if (prices != null)
            {
                return prices;
            }
            lock (priceLock)
            {
                if (prices != null)
                {
                    return prices;
                }
                var url = $"{ApiHttpExecutor.ApiDomian}/Price/BidPrices?sn={snProvider.Provide()}";
                prices = executor.Get<List<BidPriceModel>>(url);
                return prices ?? new List<BidPriceModel> { };
            }
        }

        public void SetPrice(BidPriceModel price)
        {
            prices = null;
            Task.Run(() =>
            {
                price.Sn = snProvider.Provide();
                var url = $"{ApiHttpExecutor.ApiDomian}/Price/SetPrice";
                executor.Post(url, JsonConvert.SerializeObject(price));
            });
        }
    }
}
