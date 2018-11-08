using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Avengers.Caches
{
    class RedisPasswordProvider : IRedisPasswordProvider
    {
        private readonly RedisOptions _redisOptions;

        public RedisPasswordProvider(IOptions<RedisOptions> options)
        {
            _redisOptions = options.Value;
        }

        public string Provide()
        {
            return _redisOptions.RedisPassword;
        }
    }
}
