using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DkCloud.Logs
{
    public interface ILogger
    {
        void Info(string message);
        void Exception(Exception ex);
    }
}
