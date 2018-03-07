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
    delegate string AutoBidHandler(string url, string paras);

    class Bidder
    {
        private readonly string _bidurl = "http://eb.ansteel.cn/sales-web/oneBidSoShopCart/bid";
        private readonly AutoBidHandler bidder;
        private readonly BidHttpExecutor executor = new BidHttpExecutor();
        private readonly BidPriceService bidPriceService = new BidPriceService();

        public Bidder()
        {
            bidder = new AutoBidHandler(executor.Post);
        }

        public void AutoBid(string idResoTemp, int money)
        {
            var max = bidPriceService.GetPrices().FirstOrDefault(p => p.IdResoTemp == idResoTemp);
            if (max == null || money > max.MaxPrice)
            {
                return;
            }
            AutoBidMethod(idResoTemp, money);
        }

        protected void AutoBidMethod(string idResoTemp, int money)
        {
            string url = string.Format(this._bidurl, idResoTemp, money);
            AutoBidRequestModel autoBidRequestModel = new AutoBidRequestModel(idResoTemp, money);
            string arg = JsonConvert.SerializeObject(autoBidRequestModel);
            string paras = string.Format("dataset={0}&time=914&resourceId=", arg);
            this.bidder.BeginInvoke(url, paras, null, null);
        }
    }
}
