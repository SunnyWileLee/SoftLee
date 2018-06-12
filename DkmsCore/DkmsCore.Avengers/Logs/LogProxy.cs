using DkmsCore.Avengers.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Avengers.Logs
{
    public class LogProxy : ILogProxy
    {
        private readonly IHttpExecuter _httpExecuter;

        private string 

        public async Task Exception(Exception exception)
        {
            throw new NotImplementedException();
        }

        public async Task Info(string message)
        {
            throw new NotImplementedException();
        }

        public async Task Warn(string message)
        {
            throw new NotImplementedException();
        }
    }
}
