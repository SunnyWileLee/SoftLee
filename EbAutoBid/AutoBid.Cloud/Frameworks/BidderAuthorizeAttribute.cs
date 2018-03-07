using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace AutoBid.Cloud.Frameworks
{
    class BidderAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var anonymous = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>();
            if (anonymous.Any())
            {
                return true;
            }
            var exception = actionContext.Request.Properties.Any(p => p.Key == BidderIdentityMessageHandler.NoTokenExceptionKey);
            return !exception;
        }
    }
}