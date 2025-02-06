using SQLite;
using Risk2.Data.Models;

namespace Risk2.Data.Repositories;

public class UserRepository(string dbPath)
{
    string _dbPath = dbPath;

    public string StatusMessage { get; set; } = "";
    //Private SQLiteConnection field
    private SQLiteConnection? conn;

    private void Init()
    {
        //Initialization code for the SQLite DB only runs once
        if (conn != null)
            return;

        conn = new SQLiteConnection(_dbPath);
        conn.CreateTable<User>();
    }

    /// <summary>
    /// Add a new user to the Database
    /// </summary>
    /// <param name="user"></param>
    public void AddNewUser(User user)
    {
        int result = 0;
        try
        {
            Init(); //Ensure the db is initialized;

            //MVP: Only Username is validated
            if (string.IsNullOrEmpty(user.Username))
                throw new Exception("Valid name required");

            if (conn != null)
                result = conn.Insert(user);

            StatusMessage = $"{result} record(s) added (Username: {user.Username})";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Failed to add {user.Username}. Error: {ex.Message}";
        }
    }

}