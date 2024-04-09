using StackExchange.Redis;
using ToWatchList.Interfaces;

namespace ToWatchList.Data
{
    public class RedisService : IDatabaseStorage
    {
        private readonly IDatabase redisDb;
        private static string listKeyName = "toWatchList";
        
        public RedisService(string connectionString)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(connectionString);
            redisDb = redis.GetDatabase();
        }

        public async Task<long> AddToListAsync(string media)
        {
            return await redisDb.ListRightPushAsync(listKeyName, media);
        }

        public async Task<List<string>> GetListAsync()
        {
            var redisValues = await redisDb.ListRangeAsync(listKeyName);
            List<string> stringList = redisValues.Select(value => value.ToString()).ToList();
            return stringList;
        }

        public async Task<long> RemoveFromListAsync(string item)
        {
            return await redisDb.ListRemoveAsync(listKeyName, item);
        }
    }
}
