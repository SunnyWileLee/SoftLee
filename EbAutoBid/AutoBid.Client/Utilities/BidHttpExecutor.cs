using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoBid.Client.Utilities
{
    class BidHttpExecutor : BaseHttpExecutor
    {
        protected override void WrapperGetRequest(HttpWebRequest request)
        {
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.CookieContainer = CookieHelper.Cookies;
        }

        protected override void WrapperGetResponse(HttpWebResponse response)
        {
            response.Cookies = CookieHelper.Cookies.GetCookies(response.ResponseUri);
        }

        protected override void WrapperPostRequest(HttpWebRequest request)
        {
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.CookieContainer = CookieHelper.Cookies;
        }

        protected override void WrapperPostResponse(HttpWebResponse response)
        {
            response.Cookies = CookieHelper.Cookies.GetCookies(response.ResponseUri);
        }
    }
}
