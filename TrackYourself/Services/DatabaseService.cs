using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TrackYourself.Models;

namespace TrackYourself.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _databaseConnection;

        public DatabaseService()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "locations.db");
            _databaseConnection = new SQLiteAsyncConnection(dbPath);
            _databaseConnection.CreateTableAsync<LocationRecord>().Wait();
        }

        public Task<int> SaveLocationAsync(LocationRecord location)
        {
            return _databaseConnection.InsertAsync(location);
        }

        public Task<List<LocationRecord>> GetLocationsAsync()
        {
            return _databaseConnection.Table<LocationRecord>().ToListAsync();
        }
    }
}
