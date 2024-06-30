using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace MultiShop.Basket.Settings
{
    public class RedisService
    {
        private ConnectionMultiplexer _connectionMultiplexer;
        private readonly RedisSettings _redisSettings;
        public RedisService(IOptions<RedisSettings> redisSettingsOptions)
        {
            _redisSettings = redisSettingsOptions.Value;
        }

        public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_redisSettings.Host}:{_redisSettings.Port}");
        public IDatabase GetDatabase(int db = 1) => _connectionMultiplexer.GetDatabase(db);
    }
}
