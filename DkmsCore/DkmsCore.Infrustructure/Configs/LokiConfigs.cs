using DkmsCore.Infrustructure.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Infrustructure.Configs
{
    public class LokiConfigs : HttpProxy, ILokiConfigs
    {
        private readonly IHttpExecuter _httpExecuter;

        public LokiConfigs(IHttpExecuter httpExecuter)
        {
            _httpExecuter = httpExecuter;
        }

        public async Task<string> Config(string key)
        {
            var action = "Config";
            var url = base.BuildUrl(action, $"key={key}");
            return await _httpExecuter.GetAsync(url);
        }
    }
}
