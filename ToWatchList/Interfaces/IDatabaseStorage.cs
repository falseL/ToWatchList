namespace ToWatchList.Interfaces
{
    public interface IDatabaseStorage
    {
        Task<string> GetAsync(string key);
        Task<bool> SetAsync(string key, string value);
    }
}