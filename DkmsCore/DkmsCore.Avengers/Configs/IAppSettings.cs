using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Avengers.Configs
{
    public interface IAppSettings
    {
        string AppId { get; }
        string AppSecret { get; }
        string GatewayHost { get; }
        Task<string> Setting(string key);
    }
}
