using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Infrustructure.Caches
{
    class RedisConnectionStringProvider : IRedisConnectionStringProvider
    {
        private readonly RedisOptions _redisOptions;

        public RedisConnectionStringProvider(IOptions<RedisOptions> options)
        {
            _redisOptions = options.Value;
        }

        public string Provide()
        {
            return _redisOptions.RedisConnection;
        }
    }
}
