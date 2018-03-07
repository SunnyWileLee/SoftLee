using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AutoBid.Cloud.Repositories.Price
{
    [Table("BidPrice")]
    class BidPriceEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Sn { get; set; }
        public int MaxPrice { get; set; }
        public string IdResoTemp { get; set; }
    }
}