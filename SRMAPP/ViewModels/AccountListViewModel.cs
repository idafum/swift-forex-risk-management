namespace SRMAPP.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using SRMAPP.Model;
public partial class AccountsListViewModel : ObservableObject
{

    private List<Account> _accountList;

    public List<Account> AccountList
    {
        get => _accountList;
        set => SetProperty(ref _accountList, value);
    }

    public AccountsListViewModel()
    {
        _accountList = [];
        //Initialize Accounts
        AccountList.Add(new Account("FTMO 1", 10000, 0.02));
        AccountList.Add(new Account("FTMO 2", 10000, 0.01));
        AccountList.Add(new Account("FTMO 3", 10000, 0.01));

    }
}