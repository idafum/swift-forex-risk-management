using System.Diagnostics;
using Risk2.Data.Models;
using Risk2.Data.Repositories;

namespace Risk2.Backend;

public class AccountManager
{
    private readonly AccountsRepository _accountRepo;
    public AccountManager(AccountsRepository accountsRepository)
    {
        _accountRepo = accountsRepository;
    }

    /// <summary>
    /// Add Accounts Handler
    /// Communicate with database to add a new account for a user
    /// </summary>
    /// <returns></returns>
    public async Task<Account> HandleAddAccountRequest(string accountName, string tradingCurrency, double initialBalance, double risk)
    {
        //Create a new account entity and set the values
        Account newAccount = new()
        {
            AccountName = accountName,
            TradingCurrency = tradingCurrency,
            InitialBalance = initialBalance,
            Risk = risk
        };

        //  bool success = await _accountRepo.AddAccountAsync();

        // if (success == false)
        // {
        //     Debug.WriteLine($"[Account Manager]: Failed to add new account");
        // }
        return null;
    }
}