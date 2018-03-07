using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBid.Client.Domain
{
    class PriceSnProvider
    {
        public string Provide()
        {
            return DateTime.Now.ToShortDateString();
        }
    }
}
