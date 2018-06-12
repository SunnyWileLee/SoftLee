using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Avengers.Net
{
    public interface IHttpExecuter
    {
        Task<string> GetAsync(string url, Dictionary<string, string> headers = null);
        Task<string> PostAsync(string url, string parameters, Dictionary<string, string> headers = null);
    }
}
