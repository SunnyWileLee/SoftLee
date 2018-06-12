using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Avengers.Configs
{
    public class ConfigProxy : IConfigProxy
    {
        private readonly IAppSettings _appSettings;
        private readonly ILokiConfigs _hulkConfigs;

        public ConfigProxy(IAppSettings appSettings, ILokiConfigs hulkConfigs)
        {
            _appSettings = appSettings;
            _hulkConfigs = hulkConfigs;
        }

        public IAppSettings AppSettings => _appSettings;

        public ILokiConfigs HulkConfigs => _hulkConfigs;
    }
}
