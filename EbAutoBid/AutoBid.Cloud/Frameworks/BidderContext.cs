using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace AutoBid.Cloud.Frameworks
{
    public class BidderContext
    {
        public Guid UserId { get; private set; }

        public static BidderContext Current
        {
            get
            {
                var principal = Thread.CurrentPrincipal as BidderPrincipal;
                return new BidderContext
                {
                    UserId = principal.UserId
                };
            }
        }
    }
}