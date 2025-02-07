/*
    The User Repository uses the DB connetction string to manipulate the User Table
*/
using SQLite;
using Risk2.Data.Models;
using System.Threading.Tasks;
using SQLitePCL;
using CoreImage;
using System.Data.Common;
using System.Diagnostics;
using AuthenticationServices;

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

    /// <summary>
    /// This method query the database to find and return a User 
    /// with the Username and Password
    /// </summary>
    /// <param name="username">Username</param>
    /// <param name="password">Password</param>
    /// <returns>The User if User exixts or Null</returns>
    public async Task<User?> GetUserByCredentialsAsync(string username, string password)
    {
        try
        {
            if (_conn != null)
            {
                return await _conn.Table<User>()
                                .Where(u => u.Username == username && u.Password == password)
                                .FirstOrDefaultAsync();
            }
            return null; //if connection is not valid
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[SQLite] Error Getting User By Credentials: {ex.Message}");
            return null;
        }
    }

    public async Task<bool> SignUpUserAsync(string firstname, string lastname, string username, string password)
    {
        try
        {
            if (_conn != null)
            {
                //Check if username exists
                var existingUser = await _conn.Table<User>().Where(u => u.Username == username).FirstOrDefaultAsync();

                if (existingUser != null)
                {
                    Debug.WriteLine("[SQLite] Username already taken");
                    return false;
                }

                var newUser = new User
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Username = username,
                    Password = password
                };

                //Insert new user to database
                int result = await _conn.InsertAsync(newUser);

                return result > 0;
            }
            else
                return false;

        }
        catch (Exception ex)
        {
            return false;
        }
    }

}