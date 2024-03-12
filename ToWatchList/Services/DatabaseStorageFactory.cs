using ToWatchList.Interfaces;

namespace ToWatchList.Services
{
    public static class DatabaseStorageFactory
    {
        public static IDatabaseStorage GetDatabaseStorage()
        {
            return new RedisService("redis-12643.c10.us-east-1-4.ec2.cloud.redislabs.com:12643,password=zKuZ9qd2zxtecyM3mFhMifzQ6HerkGQ3");
        }
    }
}