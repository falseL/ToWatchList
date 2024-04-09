using System.Data.SQLite;
using ToWatchList.Interfaces;

namespace ToWatchList.Data
{
    public class SQLiteService : IDatabaseStorage
    {
        private readonly string connectionString;
        private static string tableName = "toWatchList";

        public SQLiteService(string dbPath)
        {
            connectionString = $"Data Source={dbPath};Version=3;";
            EnsureTableExists();
        }

        private void EnsureTableExists()
        {
            using var connection = new SQLiteConnection(connectionString);
            connection.Open();
            using var command = new SQLiteCommand($"CREATE TABLE IF NOT EXISTS {tableName} (Id INTEGER PRIMARY KEY, Media TEXT NOT NULL)", connection);
            command.ExecuteNonQuery();
        }

        public async Task<long> AddToListAsync(string media)
        {
            using var connection = new SQLiteConnection(connectionString);
            await connection.OpenAsync();
            using var command = new SQLiteCommand($"INSERT INTO {tableName} (Media) VALUES (@media)", connection);
            command.Parameters.AddWithValue("@media", media);
            await command.ExecuteNonQueryAsync();
            return connection.LastInsertRowId;
        }

        public async Task<List<string>> GetListAsync()
        {
            var list = new List<string>();
            using var connection = new SQLiteConnection(connectionString);
            await connection.OpenAsync();
            using var command = new SQLiteCommand($"SELECT Media FROM {tableName}", connection);
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(reader.GetString(0));
            }
            return list;
        }

        public async Task<long> RemoveFromListAsync(string item)
        {
            using var connection = new SQLiteConnection(connectionString);
            await connection.OpenAsync();
            using var command = new SQLiteCommand($"DELETE FROM {tableName} WHERE Media = @media", connection);
            command.Parameters.AddWithValue("@media", item);
            return await command.ExecuteNonQueryAsync();
        }
    }
}
