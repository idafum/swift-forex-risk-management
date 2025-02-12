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
    public async Task<Account?> HandleAddAccountRequest(string accountName, string tradingCurrency, double initialBalance, double risk)
    {
        //Create a new account entity and set the values
        Account newAccount = new()
        {
            OwnerID = Preferences.Get("userId", -1),

            //Database sets the Account ID

            TradingCurrency = tradingCurrency,
            AccountName = accountName,
            InitialBalance = initialBalance,
            Risk = risk,
            CurrentBalance = initialBalance,

            //The current state is 0.0 at account creation
            CurrentState = 0.0 //BaseLine
        };

        Account? account = await _accountRepo.AddAccountAsync(newAccount);

        return account;
    }

    /// <summary>
    /// GetAccountsHandler
    /// 
    /// Communicate with the data base to get a user accounts;
    /// </summary>
    /// <param name="userId">userId</param>
    /// <returns>A list of User accounts</returns>
    public async Task<List<Account>> HandleGetAccountsRequest(int userId)
    {
        List<Account> accountList = await _accountRepo.GetUserAccountsAsync(userId);

        return accountList;
    }
}