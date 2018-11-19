using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Infrustructure.Webs
{
    public class DkmsResultMiddleWare : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult)
            {
                var objectResult = context.Result as ObjectResult;
                if (objectResult.Value == null)
                {
                    SetResponse(context, DkmsResult.Success(string.Empty));
                }
                else
                {
                    SetResponse(context, DkmsResult.Success(objectResult.Value));
                }
            }
            else if (context.Result is EmptyResult)
            {
                SetResponse(context, DkmsResult.Success(string.Empty));
            }
            else if (context.Result is ContentResult)
            {
                SetResponse(context, DkmsResult.Success((context.Result as ContentResult).Content));
            }
        }

        private void SetResponse(ResultExecutingContext context, DkmsResult result)
        {
            context.Result = new ObjectResult(result);
        }
    }
}
