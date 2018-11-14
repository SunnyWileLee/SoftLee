using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Infrustructure.Caches
{
    class RedisCaching : IRedisCaching
    {
        private readonly IRedisDatabaseProvider _databaseProvider;
        private readonly IRedisExpiryProvider _expiryProvider;
        private readonly IRedisPrefixProvider _prefixProvider;

        public RedisCaching(IRedisDatabaseProvider databaseProvider, IRedisExpiryProvider expiryProvider, IRedisPrefixProvider prefixProvider)
        {
            _databaseProvider = databaseProvider;
            _expiryProvider = expiryProvider;
            _prefixProvider = prefixProvider;
        }

        private string FormatKey(string key, bool ignorePrefix)
        {
            if (ignorePrefix)
            {
                return key;
            }
            var prefix = _prefixProvider.Provide();
            return string.Format("{0}:{1}", prefix, key);
        }

        public async Task<string> GetAsync(string key, bool ignorePrefix = false)
        {
            try
            {
                key = FormatKey(key, ignorePrefix);
                var database = _databaseProvider.Provide();
                if (!database.KeyExists(key))
                {
                    return string.Empty;
                }
                var value = await database.StringGetAsync(key);
                return value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TModel> GetAsync<TModel>(string key, bool ignorePrefix = false)
        {
            var value = await this.GetAsync(key, ignorePrefix);
            return JsonConvert.DeserializeObject<TModel>(value);
        }

        public async Task InsertAsync(string key, object value, int expiry = 1800, bool ignorePrefix = false)
        {
            try
            {
                key = FormatKey(key, ignorePrefix);
                if (expiry == 0)
                {
                    expiry = _expiryProvider.Provide();
                }
                var type = value.GetType();
                var json = string.Empty;
                if (type.IsValueType || type == typeof(string))
                {
                    json = value.ToString();
                }
                else
                {
                    json = JsonConvert.SerializeObject(value);
                }
                var database = _databaseProvider.Provide();
                var timeSpan = TimeSpan.FromSeconds(expiry);
                await database.StringSetAsync(key, json, timeSpan);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
