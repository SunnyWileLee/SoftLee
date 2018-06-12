using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Avengers.Configs
{
    public interface IConfigProxy
    {
        IAppSettings AppSettings { get; }
        ILokiConfigs HulkConfigs { get; }
    }
}
