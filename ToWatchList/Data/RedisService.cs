using StackExchange.Redis;
using ToWatchList.Interfaces;

namespace ToWatchList.Data
{
    public class RedisService : IDatabaseStorage
    {
        private readonly IDatabase redisDb;
        public RedisService(string connectionString)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(connectionString);
            redisDb = redis.GetDatabase();
        }

        public async Task<string> GetAsync(string key)
        {
            return await redisDb.StringGetAsync(key);
        }

        public async Task<bool> SetAsync(string key, string value)
        {
            return await redisDb.StringSetAsync(key, value);
        }
    }
}
