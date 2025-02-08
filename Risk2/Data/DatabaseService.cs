/*
    DatabaseService uses the SQLiteAsyncConnection to initialize tables.
*/
using SQLite;
using Risk2.Data.Models;
using System;
using System.Threading.Tasks;

namespace Risk2.Data
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _db;
        public DatabaseService(SQLiteAsyncConnection connection) //DI
        {
            _db = connection;
        }

        /// <summary>
        /// Async initialization
        /// </summary>
        /// <returns></returns>
        public async Task InitializeAsync()
        {
            await _db.CreateTableAsync<User>();

        }
    }
}
