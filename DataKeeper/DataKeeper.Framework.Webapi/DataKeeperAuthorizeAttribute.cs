using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace DataKeeper.Framework.Webapi
{
    public class DataKeeperAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var anonymous = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>();
            if (anonymous.Any())
            {
                return true;
            }
            var exception = actionContext.Request.Properties.Any(p => p.Key == DataKeeperUserMessageHandler.NoTokenExceptionKey);
            return !exception;
        }
    }
}
