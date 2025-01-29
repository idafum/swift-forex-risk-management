
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SRMAPP.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SRMAPP.ViewModels;
public partial class AccountListViewModel : ObservableObject
{

    public AccountListViewModel()
    {
        AccountList = [];
        AccountList.Add(new Account());
    }

    [ObservableProperty]
    ObservableCollection<Account> accountList = [];

    [RelayCommand]
    void Delete(Account account)
    {
        Console.WriteLine("Executing Delete Command");
        if (account != null)
        {
            AccountList.Remove(account);
        }
    }
}