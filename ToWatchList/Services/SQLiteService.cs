using ToWatchList.Interfaces;

namespace ToWatchList.Services
{
    public class SQLiteService : IDatabaseStorage
    {
        public Task<string> GetAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetAsync(string key, string value)
        {
            throw new NotImplementedException();
        }
    }
}
