using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace AutoBid.Cloud.Frameworks
{
    public class BidderPrincipal : IPrincipal
    {
        private BidderIdentity _identity;

        public IIdentity Identity
        {
            get
            {
                if (_identity == null)
                {
                    _identity = new BidderIdentity { UserId = this.UserId };
                }
                return _identity;
            }
        }

        public bool IsInRole(string role)
        {
            return true;
        }

        public Guid UserId { get; set; }
    }
}