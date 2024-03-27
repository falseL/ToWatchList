namespace ToWatchList.Interfaces
{
    public interface IDatabaseStorage
    {
        Task<long> AddToListAsync(string media);
        Task<List<string>> GetListAsync();
    }
}