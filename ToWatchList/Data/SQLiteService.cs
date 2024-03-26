using ToWatchList.Interfaces;

namespace ToWatchList.Data
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
