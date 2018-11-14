using System;
using System.Collections.Generic;
using System.Text;
using StackExchange.Redis;

namespace DkmsCore.Infrustructure.Caches
{
    class RedisDatabaseProvider : IRedisDatabaseProvider
    {
        private readonly IRedisConnectionStringProvider _connectionStringProvider;
        private readonly IRedisPasswordProvider _passwordProvider;

        private static ConnectionMultiplexer connectionMultiplexer;
        private static object multiplexerLock = new object();

        public RedisDatabaseProvider(IRedisConnectionStringProvider connectionStringProvider,
                                     IRedisPasswordProvider passwordProvider)
        {
            _connectionStringProvider = connectionStringProvider;
            _passwordProvider = passwordProvider;
        }

        public IRedisPasswordProvider PasswordProvider
        {
            get
            {
                return _passwordProvider;
            }
        }

        public IDatabase Provide()
        {
            if (connectionMultiplexer == null)
            {
                lock (multiplexerLock)
                {
                    if (connectionMultiplexer == null)
                    {
                        var connectionString = _connectionStringProvider.Provide();
                        var options = ConfigurationOptions.Parse(connectionString);
                        var password = _passwordProvider.Provide();
                        if (!string.IsNullOrEmpty(password))
                        {
                            options.Password = password;
                        }
                        var size = options.WriteBuffer;
                        options.ConnectTimeout = 20000;
                        options.SyncTimeout = 20000;
                        connectionMultiplexer = ConnectionMultiplexer.Connect(options);
                    }
                }
            }

            return connectionMultiplexer.GetDatabase();
        }
    }
}
