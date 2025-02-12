/* This Viewmodel combines the Create Account View and the Account model
    It creates a new account object and returs that object to the calling viewmodel
*/
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace Risk2.ViewModels;

public partial class CreateAccountViewModel : ObservableObject
{

    [ObservableProperty]
    string accountName;

    [ObservableProperty]
    double accountBalance;

    [ObservableProperty]
    string tradingCurrency;

    [ObservableProperty]
    double risk;


    readonly IPopupService popupService;

    public CreateAccountViewModel(IPopupService popupService)
    {
        this.popupService = popupService;

        AccountName = "";
        AccountBalance = 0;
        TradingCurrency = "USD";
        Risk = 2;
    }

    /// <summary>
    /// This can only execute if the user entry is validate
    /// </summary>
    [RelayCommand(CanExecute = nameof(IsValidated))]
    private void Done()
    {
        //TODO..
        //Handle Entry Validation in IsValidated 

        //Close the popup, returning a tuple of account information
        var newAccountInfo = (AccountName, AccountBalance, TradingCurrency, Risk);
        popupService.ClosePopup(newAccountInfo);
    }

    /// <summary>
    /// Is the account info valid
    /// Account Name: Can be alphanumeric and 3 > x < 10 characters
    /// Balance: Minimum of 10 dollars
    /// Risk: Minumum risk of 0.5%
    /// </summary>
    /// <returns></returns>
    private bool IsValidated()
    {
        //Handle Entry Validation
        return true;
    }

    /// <summary>
    /// Close popup and return null to the the caller
    /// </summary>
    [RelayCommand]
    private void Cancel()
    {
        popupService.ClosePopup(null);
    }

}