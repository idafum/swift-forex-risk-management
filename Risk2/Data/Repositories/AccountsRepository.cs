using System.Diagnostics;
using Risk2.Data.Models;
using SQLite;

namespace Risk2.Data.Repositories;

public class AccountsRepository
{
    private readonly SQLiteAsyncConnection? _conn;
    public AccountsRepository(SQLiteAsyncConnection conn)
    {
        _conn = conn;
    }

    /// <summary>
    /// This method adds an account for a user to the account table
    /// </summary>
    /// <param name="UserId"></param>
    /// <param name="account"></param>
    /// <returns></returns>
    public async Task<Account?> AddAccountAsync(Account account)
    {
        if (_conn == null)
        {
            return null;
        }
        try
        {
            int result = await _conn.InsertAsync(account);
            return result > 0 ? account : null;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[Database] Failed to add new account: {ex.Message}");
            return null;
        }
    }
}