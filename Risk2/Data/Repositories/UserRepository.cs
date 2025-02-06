/*
    The User Repository uses the DB connetction string to manipulate the User Table
*/
using SQLite;
using Risk2.Data.Models;
using System.Threading.Tasks;
using SQLitePCL;
using CoreImage;
using System.Data.Common;

namespace Risk2.Data.Repositories;

public class UserRepository
{
    public string StatusMessage { get; set; } = "";
    private readonly SQLiteAsyncConnection? _conn;

    public UserRepository(SQLiteAsyncConnection conn) //Injected using DI
    {
        _conn = conn;
    }

    /// <summary>
    /// Add a new user to the Database
    /// </summary>
    /// <param name="user"></param>
    public async Task AddNewUser(User user)
    {
        int result = 0;
        try
        {
            //MVP: Only Username is validated
            if (string.IsNullOrEmpty(user.Username))
                throw new Exception("Valid name required");

            if (_conn != null)
                result = await _conn.InsertAsync(user);

            StatusMessage = $"{result} record(s) added (Username: {user.Username})";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Failed to add {user.Username}. Error: {ex.Message}";
        }
    }

}