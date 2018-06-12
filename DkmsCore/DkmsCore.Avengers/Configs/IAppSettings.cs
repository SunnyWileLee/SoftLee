using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Avengers.Configs
{
    public interface IAppSettings
    {
        string AppId { get; }
        string AppSecret { get; }
        string GatewayHost { get; }
        string Setting { get; }
    }
}
