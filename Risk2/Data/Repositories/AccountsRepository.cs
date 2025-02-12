using System.Diagnostics;
using System.Security.Cryptography;
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

    /// <summary>
    /// Queries the database to get a list of user accounts
    /// </summary>
    /// <param name="userId">user Id</param>
    /// <returns>A list of User accounts</returns>
    public async Task<List<Account>> GetUserAccountsAsync(int userId)
    {
        if (_conn == null)
        {
            Debug.WriteLine($"[Database] Connection Error");
            return []; //Empty list
        }
        try
        {
            var accounts = await _conn.Table<Account>()
                                    .Where(a => a.OwnerID == userId)
                                    .ToListAsync();

            if (accounts.Count == 0)
            {
                Debug.WriteLine($"[Database] No accounts found for User ID: {userId}");
            }
            return accounts;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[SQLite] Error getting user accounts: {ex.Message}");
            return [];
        }
    }

    /// <summary>
    /// Queries the database to delete an account
    /// </summary>
    /// <param name="accountId">account id</param>
    /// <returns>true if account was deleted and false if not</returns>
    public async Task<bool> DeleteAccount(int accountId)
    {
        if (_conn == null)
        {
            Debug.WriteLine($"[Database] Connection Error");
            return false;
        }
        try
        {
            int result = 0;
            result = await _conn.DeleteAsync<Account>(accountId);

            return result > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[SQLite] Error deleting account {accountId}: {ex.Message}");
            return false;
        }
    }
}