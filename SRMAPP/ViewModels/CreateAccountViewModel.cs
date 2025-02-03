/* This Viewmodel combines the Create Account View and the Account model
    It creates a new account object and returs that object to the calling viewmodel
*/
using System.Runtime.ConstrainedExecution;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SRMAPP.Model;

namespace SRMAPP.ViewModels;

public partial class CreateAccountViewModel : ObservableObject
{

    [ObservableProperty]
    Account newAccount = new();

    readonly IPopupService popupService;

    public CreateAccountViewModel(IPopupService popupService)
    {
        this.popupService = popupService;
    }


    [RelayCommand]
    private void Done()
    {

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