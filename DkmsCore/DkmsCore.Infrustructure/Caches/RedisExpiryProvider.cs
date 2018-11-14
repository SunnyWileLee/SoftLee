using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Infrustructure.Caches
{
    class RedisExpiryProvider : IRedisExpiryProvider
    {
        private readonly RedisOptions _redisOptions;

        public RedisExpiryProvider(IOptions<RedisOptions> options)
        {
            _redisOptions = options.Value;
        }

        public int Provide()
        {
            var expiry = _redisOptions.RedisExpiry;
            if (expiry <= 0)
            {
                expiry = 1800;
            }
            return expiry;
        }
    }
}
