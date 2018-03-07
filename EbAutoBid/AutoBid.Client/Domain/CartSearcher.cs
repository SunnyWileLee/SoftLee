using AutoBid.Client.Models;
using AutoBid.Client.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutoBid.Client.Domain
{
    class CartSearcher
    {
        public readonly string Url = "http://eb.ansteel.cn/sales-web/oneBidSoShopCart/returnOneBidShopCart";

        private readonly string _regex = "<divclass=\"prodDes\">(.*?)</div>(.*?)<divclass=\"pieceAmoRows\">(.*?)<span>(.*?)</span>(.*?)<divclass=\"unitPriceRows\"(.*?)<span>(.*?)</span>(.*?)<divclass=\"addedTotalMoneyRows\"(.*?)<divclass=\"addedGradientRows\">(.*?)<span>(.*?)</span>(.*?)<divclass=\"highestPrceRows\">(.*?)<spanclass=\"highestPrceRowsShow\">(.*?)</span>[<span>(.*?)</span>]?(.*?)<divclass=\"myPriceRows\">(.*?)value=\"(.*?)\"(.*?)<divclass=\"aheadRows\">(.*?)<spanclass=\"aheadRowsShow\">(.*?)</span>(.*?)<divclass=\"assureRows\">(.*?)<span(.*?)</span>";

        private readonly string _regexInfo1 = "<divclass=\"prodAndQual\">(.*?)<spantitle(.*?)?recordId=(.*?)\">(.*?)</a></span>(.*?)<span(.*?)\">(.*?)</span>";

        private readonly string _regexInfo2 = "pointer\">(.*?)<";

        private readonly string _regexCprice = "span>(.*?)</span>";

        public List<ProductModel> Search()
        {
            List<ProductModel> list = new List<ProductModel>();
            BidHttpExecutor httpExecutor = new BidHttpExecutor();
            string input = httpExecutor.Get(this.Url).Replace("\r\n", string.Empty).Replace("\r", string.Empty).Replace("\n", string.Empty).Replace(" ", string.Empty).Replace(" ", string.Empty);
            Regex regex = new Regex(this._regex);
            Regex regex2 = new Regex(this._regexInfo1);
            Regex regex3 = new Regex(this._regexInfo2);
            Regex regex4 = new Regex("idResoTemp=\"(.*?)\"");
            Regex regex5 = new Regex(this._regexCprice);
            MatchCollection matchCollection = regex.Matches(input);
            foreach (Match match in matchCollection)
            {
                string value = match.Groups[23].Value;
                if (!value.Contains("确认出价"))
                {
                    continue;
                }
                ProductModel product = new ProductModel();
                string value2 = regex4.Match(value).Groups[1].Value;
                product.IdResoTemp = value2;
                product.Info = string.Empty;
                string value3 = match.Groups[1].Value;
                MatchCollection matchCollection2 = regex2.Matches(value3);
                Match match2 = matchCollection2[0];
                product.Info += match2.Groups[4].Value;
                product.Info += match2.Groups[7].Value;
                string value4 = match.Groups[2].Value;
                MatchCollection matchCollection3 = regex3.Matches(value4);
                foreach (Match match3 in matchCollection3)
                {
                    product.Info += match3.Groups[1].Value;
                }
                product.Weight = match.Groups[4].Value;
                product.Price = match.Groups[7].Value;
                int currentPrice = 0;
                string value5 = match.Groups[14].Value;
                int.TryParse(value5, out currentPrice);
                product.CurrentPrice = currentPrice;
                int myPrice = 0;
                int.TryParse(match.Groups[17].Value, out myPrice);
                product.MyPrice = myPrice;
                product.IsOwn = match.Groups[20].Value.Equals("领先");
                list.Add(product);
            }
            return list;
        }
    }
}
