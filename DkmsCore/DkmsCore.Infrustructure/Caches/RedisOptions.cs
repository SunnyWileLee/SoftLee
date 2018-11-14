using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Infrustructure.Caches
{
    public class RedisOptions
    {
        public int RedisExpiry { get; set; }
        public string RedisConnection { get; set; }
        public string RedisPassword { get; set; }
        public string RedisPrefix { get; set; }
    }
}
