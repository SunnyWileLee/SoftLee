using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoBid.Cloud.Models.Price
{
    public class BidPriceModel : BaseModel
    {
        public Guid UserId { get; set; }
        [Required]
        public string Sn { get; set; }
        public int MaxPrice { get; set; }
        [Required]
        public string IdResoTemp { get; set; }
    }
}