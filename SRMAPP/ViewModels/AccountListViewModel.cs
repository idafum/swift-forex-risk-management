
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using SRMAPP.Model;
using SRMAPP.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SRMAPP.ViewModels;
public partial class AccountListViewModel : ObservableObject
{

    public AccountListViewModel()
    {
        AccountList = [];
        AccountList.Add(new Account());
        AccountList.Add(new Account());
        AccountList.Add(new Account());
    }

    [ObservableProperty]
    ObservableCollection<Account> accountList = [];

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

    [RelayCommand]
    async Task CreateAccount()
    {
        await Shell.Current.Navigation.PushModalAsync(new AccountCreationFormPage());
        //Open the account creation popup,
        // Account Name
        // Account Balance
        // Account Risk
    }
}