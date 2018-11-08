using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Avengers.Caches
{
    class RedisPrefixProvider : IRedisPrefixProvider
    {
        private readonly RedisOptions _redisOptions;

        public RedisPrefixProvider(IOptions<RedisOptions> options)
        {
            _redisOptions = options.Value;
        }

        public string Provide()
        {
            return _redisOptions.RedisPrefix;
        }
    }
}
