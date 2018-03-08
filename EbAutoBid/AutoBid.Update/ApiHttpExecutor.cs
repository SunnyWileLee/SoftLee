using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoBid.Update
{
    class ApiHttpExecutor : BaseHttpExecutor
    {
        public const string ApiDomian = "http://115.159.109.158:5456/";

        protected override void WrapperGetRequest(HttpWebRequest request)
        {
            request.ContentType = "application/json; charset=UTF-8";
        }

        protected override void WrapperGetResponse(HttpWebResponse response)
        {

        }

        protected override void WrapperPostRequest(HttpWebRequest request)
        {
            request.ContentType = "application/json; charset=UTF-8";
        }

        protected override void WrapperPostResponse(HttpWebResponse response)
        {

        }
    }
}
