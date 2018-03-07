using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBid.Client.Models
{
    class ProductModel
    {
        public string Info { get; set; }
        public string Weight { get; set; }
        public string Price { get; set; }
        public int CurrentPrice { get; set; }
        public int MyPrice { get; set; }
        public int MaxPrice { get; set; }
        public bool IsOwn { get; set; }
        public string IdResoTemp { get; set; }
    }
}
