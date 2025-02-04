

using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using Risk2.Model;
using Risk2.Popups;
using Risk2.Views;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Risk2.ViewModels;
public partial class AccountListViewModel : ObservableObject
{
    private readonly IPopupService popupService;

    public AccountListViewModel(IPopupService popupService)
    {
        AccountList = [];

        AccountList.Add(new Account());
        AccountList.Add(new Account());
        AccountList.Add(new Account());
        this.popupService = popupService;
    }

    [ObservableProperty]
    ObservableCollection<Account> accountList;

    /// <summary>
    /// Delete an account from the account List View. 
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    [RelayCommand]
    async Task Delete(Account account)
    {
        if (account != null)
        {
            Debug.WriteLine("Account is not null");
            var currentPage = Shell.Current;
            if (currentPage != null)
            {
                bool answer = await Shell.Current.DisplayAlert("Confirm Delete", "Are you sure you want to delete this account?", "Yes", "No");
                Debug.WriteLine("Answer: " + answer);

                if (answer)
                {
                    AccountList.Remove(account);
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

        var acc = await this.popupService.ShowPopupAsync<CreateAccountViewModel>();

        //Add new account to account list if valid.
        if (acc != null && acc is Account newAccount)
        {
            AccountList.Add(newAccount);
        }

    }
}