using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dkms.Tools.Net
{
    public interface IHttpExecuter
    {
        string Get(string url, Dictionary<string, string> headers = null);
        Task<string> GetAsync(string url, Dictionary<string, string> headers = null);
        string Post(string url, object parameters, Dictionary<string, string> headers = null);
        Task<string> PostAsync(string url, object parameters, Dictionary<string, string> headers = null);
    }
}
