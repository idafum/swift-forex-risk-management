using SQLite;
using Risk2.Data.Models;
using System;
using System.Threading.Tasks;

namespace Risk2.Data
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _db;

        public DatabaseService(SQLiteAsyncConnection connection)
        {
            _db = connection;
        }

        public async Task InitializeAsync()
        {
            await _db.CreateTableAsync<User>();

        }
    }
}
