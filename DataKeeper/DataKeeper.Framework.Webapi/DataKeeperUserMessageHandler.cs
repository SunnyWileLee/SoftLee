using DataKeeper.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Webapi
{
    public class DataKeeperUserMessageHandler : DelegatingHandler
    {
        public const string TokenHeader = "token";
        public const string NoTokenExceptionKey = "userid_exception";

        public Func<Guid, Guid> GetUserIdAction;

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = Guid.Parse("8FF40BAF-CF97-445B-BD40-D00466E63C03");

            //var headers = request.Headers;
            //if (!headers.Any(s => s.Key.ToLower().Equals(TokenHeader)))
            //{
            //    SetNoTokenException(request.Properties);
            //    return base.SendAsync(request, cancellationToken);
            //}
            //var tokenString = headers.First(s => s.Key.ToLower().Equals(TokenHeader)).Value.FirstOrDefault();
            //var token = Guid.Empty;
            //var valid = Guid.TryParse(tokenString, out token);
            //if (!valid || token == Guid.Empty)
            //{
            //    SetNoTokenException(request.Properties);
            //    return base.SendAsync(request, cancellationToken);
            //}
            var userId = GetUserIdAction.Invoke(token);

            var principal = new DataKeeperPrincipal
            {
                UserId = userId
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
