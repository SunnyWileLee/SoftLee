using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DkCloud.Config
{
    public interface IConfigger
    {
        ConfigEntity Get(string key);
    }
}
