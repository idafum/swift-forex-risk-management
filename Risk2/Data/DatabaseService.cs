/*
    DatabaseService uses the SQLiteAsyncConnection to initialize tables.

    Note to prevent Locks, 
*/
using SQLite;
using Risk2.Data.Models;
using System;
using System.Threading.Tasks;
using System.Diagnostics;

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
        /// Initialize the database with error handling
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> InitAsync()
        {
            try
            {
                Debug.WriteLine("[Database] Initialiing database...");
                await _db.CreateTableAsync<User>();
                await _db.CreateTableAsync<Account>();

                Debug.WriteLine("[Database] Initialization successful");
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[DB4S] Ensure you close DB4S. SQLite does not support multiple concurrent write operations.");
                Debug.WriteLine($"[Database Error] Failed to initialize: {ex.StackTrace}");
                return false;
            }

        }
    }
}
