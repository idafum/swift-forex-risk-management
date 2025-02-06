using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Risk2.Views;

namespace Risk2.ViewModels;

public partial class LoginViewModel : ObservableObject
{

    [ObservableProperty]
    string? userName = null;

    [ObservableProperty]
    string? password = null;

    // TODO: Bind Login Data and handle login request
    public LoginViewModel()
    {

    }

}