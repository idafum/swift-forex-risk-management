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
    public async Task<bool> AddAccountAsync(int UserId, Account account)
    {
        return false;
    }
}