using AutoBid.Cloud.Models.Price;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBid.Cloud.Applications.Price
{
    public interface IPriceService
    {
        void SetPrice(BidPriceModel model);
    }
}
