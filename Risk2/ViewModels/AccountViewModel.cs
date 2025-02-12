
using CommunityToolkit.Mvvm.ComponentModel;
using Risk2.Data.Models;

namespace Risk2.ViewModels;

public partial class AccountViewModel : ObservableObject
{
    [ObservableProperty]
    string accountName;

    [ObservableProperty]
    double accountBalance;

    [ObservableProperty]
    double status;

    public int Id { get; init; }

    public AccountViewModel(Account account)
    {
        accountName = account.AccountName;
        accountBalance = account.CurrentBalance;
        status = account.CurrentState;
        Id = account.AccountID; //Init set
    }
}