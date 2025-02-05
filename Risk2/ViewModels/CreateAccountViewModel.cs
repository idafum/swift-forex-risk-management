/* This Viewmodel combines the Create Account View and the Account model
    It creates a new account object and returs that object to the calling viewmodel
*/
using System.Runtime.ConstrainedExecution;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Risk2.Model;

namespace Risk2.ViewModels;

public partial class CreateAccountViewModel : ObservableObject
{

    [ObservableProperty]
    Account newAccount = new();

    readonly IPopupService popupService;

    public CreateAccountViewModel(IPopupService popupService)
    {
        this.popupService = popupService;
    }

    /// <summary>
    /// This can only execute if the user entry is validate
    /// </summary>
    [RelayCommand(CanExecute = nameof(IsValidated))]
    private void Done()
    {
        //validate
        popupService.ClosePopup(NewAccount);
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