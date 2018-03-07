using AutoBid.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoBid.Client.Utilities
{
    class ApiHttpExecutor : BaseHttpExecutor
    {
        public const string ApiDomian = "http://localhost:4345/";

        protected override void WrapperGetRequest(HttpWebRequest request)
        {
            request.ContentType = "application/json; charset=UTF-8";
            if (UserModel.CurrentUserId != Guid.Empty)
            {
                request.Headers.Add("userId", UserModel.CurrentUserId.ToString());
            }
        }

        protected override void WrapperGetResponse(HttpWebResponse response)
        {

        }

        protected override void WrapperPostRequest(HttpWebRequest request)
        {
            request.ContentType = "application/json; charset=UTF-8";
            if (UserModel.CurrentUserId != Guid.Empty)
            {
                request.Headers.Add("userId", UserModel.CurrentUserId.ToString());
            }
        }

        protected override void WrapperPostResponse(HttpWebResponse response)
        {

        }
    }
}
