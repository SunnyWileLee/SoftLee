using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Infrustructure.Configs
{
    public interface ILokiConfigs
    {
        Task<string> Config(string key);
    }
}
