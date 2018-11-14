using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Infrustructure.Caches
{
    public interface IRedisCaching
    {
        Task<string> GetAsync(string key, bool ignorePrefix = false);
        Task<TModel> GetAsync<TModel>(string key, bool ignorePrefix = false);
        Task InsertAsync(string key, object value, int expiry = 1800, bool ignorePrefix = false);
    }
}
