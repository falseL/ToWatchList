using ToWatchList.Interfaces;

namespace ToWatchList.Data
{
    public class SQLiteService : IDatabaseStorage
    {
        public Task<long> AddToListAsync(string media)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetListAsync()
        {
            throw new NotImplementedException();
        }

    }
}
