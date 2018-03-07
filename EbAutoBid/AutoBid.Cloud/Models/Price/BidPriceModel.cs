using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoBid.Cloud.Models.Price
{
    public class BidPriceModel : BaseModel
    {
        public Guid UserId { get; set; }
        public string Sn { get; set; }
        public int MaxPrice { get; set; }
        public string IdResoTemp { get; set; }
    }
}