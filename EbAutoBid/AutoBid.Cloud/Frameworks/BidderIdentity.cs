using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace AutoBid.Cloud.Frameworks
{
    class BidderIdentity : IIdentity
    {
        public string Name => UserId.ToString();

        public string AuthenticationType => "head_userid";

        public bool IsAuthenticated => true;

        public Guid UserId { get; set; }
    }
}