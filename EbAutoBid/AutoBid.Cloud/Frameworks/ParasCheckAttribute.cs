using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace AutoBid.Cloud.Frameworks
{
    /// <summary>
    /// Post请求的输入参数的验证过滤器
    /// </summary>
    public class ParasCheckAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            if (actionContext.Request.Method == HttpMethod.Post)
            {
                if (actionContext.ModelState.IsValid)
                {
                    return;
                }
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);
            }
        }
    }
}