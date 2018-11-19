using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Infrustructure.Webs
{
    public class DkmsExceptionMiddleWare
    {
        private readonly RequestDelegate NextDelegate;

        public DkmsExceptionMiddleWare(RequestDelegate next)
        {
            NextDelegate = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await NextDelegate(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception == null)
            {
                return;
            }
            await WriteExceptionAsync(context, exception).ConfigureAwait(false);
        }

        private static async Task WriteExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.StatusCode = (int)HttpStatusCode.OK;
            response.ContentType = "application/json";
            await response.WriteAsync(JsonConvert.SerializeObject(DkmsResult.Failure(message: exception.Message))).ConfigureAwait(false);
        }
    }
}
