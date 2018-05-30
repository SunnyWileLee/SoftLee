using DkCloud.Eureka;
using DkCloud.Route;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DkCloud.Gateway
{
    public class MessageHandler
    {
        private readonly IRouter _router;
        private readonly IServiceConsumer _serviceConsumer;

        public void Handle(HttpRequestMessage message)
        {
            var route = _router.Route(message.RequestUri);
            var service = _serviceConsumer.Find(route);
        }
    }
}
