

using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HealthKit;
using Microsoft.Maui.Controls;
using Risk2.Backend;
using Risk2.Data.Models;
using Risk2.Popups;
using Risk2.Views;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
namespace Risk2.ViewModels;
public partial class AccountListViewModel : ObservableObject
{
    private readonly IPopupService popupService;
    private readonly AccountManager _accountManager;

    public ObservableCollection<AccountViewModel> Accounts { get; set; } = [];

    public AccountListViewModel(IPopupService popupService, AccountManager accountManager) //DI
    {
        this.popupService = popupService;
        _accountManager = accountManager;

        int userId = Preferences.Get("userId", -1);
        Task.Run(PopulateUserAccount);
    }

    /// <summary>
    /// Send request to get user accounts
    /// </summary>
    private async Task PopulateUserAccount()
    {
        Accounts.Clear(); //Clear existing accounts;

        //Send request
        var accountList = await _accountManager.HandleGetAccountsRequest(Preferences.Get("userId", -1));
        foreach (var account in accountList)
        {
            Accounts.Add(new AccountViewModel(account));
        }

    }

    /// <summary>
    /// This method is called from the OnDeleteAccount Event Handler
    /// 
    /// Delete an account from the account List View. 
    /// </summary>
    /// <param name="accountView">The viewmodel that controls the account to be deleted</param>
    /// <returns></returns>
    public async Task OnDeleteAccountInvoked(AccountViewModel accountView)
    {

        if (accountView != null)
        {
            bool answer = await Shell.Current.DisplayAlert("Confirm Delete", "Are you sure you want to delete this account?", "Yes", "No");
            if (answer)
            {
                //We query the db to remove the accounts controlled by the view model
                bool result = await _accountManager.HandleDeleteAccountRequest(accountView.Id);

                //We wait for confirmation 
                if (result)
                {
                    Accounts.Remove(accountView);

                    var toast = Toast.Make($"Account {accountView.AccountName} has been deleted");
                    await toast.Show();
                }
                else
                {
                    //Display Toast
                    var toast = Toast.Make("Failed to delete account", ToastDuration.Short, 14);
                    await toast.Show();

                }
            }
        }
    }

    /// <summary>
    /// Open the Create account popup 
    /// </summary>
    [RelayCommand]
    private async Task CreateAccount()
    {

        var accountInfo = await popupService.ShowPopupAsync<CreateAccountViewModel>(); //New Account Info returned

        //Pattern Matching    
        if (accountInfo is (string accountName, double accountBalance, string tradingCurrency, double risk))
        {
            //Send info to the accountManager
            var newAccount = await _accountManager.HandleAddAccountRequest(accountName, tradingCurrency, accountBalance, risk);

            if (newAccount == null)
            {
                //Display UI 'Unable to create new account'. Hint: You cannot create 2 accounts with the same name
                var toast = Toast.Make("Failed! Try again", ToastDuration.Short, 14);
                await toast.Show();
            }
            else
            {
                //Add this new account to the accountListViewModel
                Accounts.Add(new AccountViewModel(newAccount));

                //Display UI for account confirmation.
                var toast = Toast.Make("Account created successfully", ToastDuration.Short, 14);
                await toast.Show();
            }
        }
        else
        {
            Debug.WriteLine("Error: Unexpected return type from ShowPopupAsync.");
        }

    }
}