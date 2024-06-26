﻿using ToWatchList.Interfaces;

namespace ToWatchList.Data
{
    public static class DatabaseStorageFactory
    {
        private static IDatabaseStorage? instance = null;
        
        // singleton
        public static IDatabaseStorage GetRedisDatabaseStorage()
        {
            if (instance == null)
            {
                instance = new RedisService("redis-12643.c10.us-east-1-4.ec2.cloud.redislabs.com:12643,password=zKuZ9qd2zxtecyM3mFhMifzQ6HerkGQ3");
            }
            return instance;
        }

        // singleton
        public static IDatabaseStorage GetSQLiteDatabaseStorage()
        {
            if (instance == null)
            {
                instance = new SQLiteService("sqlite.db");
            }
            return instance;
        }
    }
}