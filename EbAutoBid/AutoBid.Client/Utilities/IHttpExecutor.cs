using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBid.Client.Utilities
{
    interface IHttpExecutor
    {
        string Post(string url, string parameters);
        TModel Post<TModel>(string url, string parameters);
        string Get(string url);
        TModel Get<TModel>(string url);
    }
}
