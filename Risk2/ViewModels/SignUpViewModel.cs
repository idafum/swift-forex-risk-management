using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Risk2.ViewModels;

public partial class SignUpViewModel : ObservableObject
{
    [ObservableProperty]
    string? firstname;
    [ObservableProperty]
    string? lastname;
    [ObservableProperty]
    string? username;
    [ObservableProperty]
    string? password;

    public SignUpViewModel()
    {
        Firstname = "Somto";
    }
}