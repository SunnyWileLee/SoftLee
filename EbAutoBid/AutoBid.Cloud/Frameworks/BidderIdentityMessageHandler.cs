using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace AutoBid.Cloud.Frameworks
{
    class BidderIdentityMessageHandler : DelegatingHandler
    {
        public const string TokenHeader = "userid";
        public const string NoTokenExceptionKey = "bidder_userid_exception";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var headers = request.Headers;
            if (!headers.Any(s => s.Key.ToLower().Equals(TokenHeader)))
            {
                SetNoTokenException(request.Properties);
                return base.SendAsync(request, cancellationToken);
            }
            var userid = headers.First(s => s.Key.ToLower().Equals(TokenHeader)).Value.FirstOrDefault();
            var guid = Guid.Empty;
            var valid = Guid.TryParse(userid, out guid);
            if (!valid || guid == Guid.Empty)
            {
                SetNoTokenException(request.Properties);
                return base.SendAsync(request, cancellationToken);
            }
            BidderPrincipal principal = new BidderPrincipal
            {
                UserId = guid
            };
            Thread.CurrentPrincipal = principal;
            return base.SendAsync(request, cancellationToken);
        }

        private void SetNoTokenException(IDictionary<string, object> properties)
        {
            var exception = new object { };
            properties.Add(NoTokenExceptionKey, exception);
        }
    }
}