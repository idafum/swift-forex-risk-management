using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using Risk2.Backend;
using Risk2.Data.Repositories;
using Risk2.Views;

namespace Risk2.ViewModels;

public partial class SignUpViewModel : ObservableObject
{

    private readonly AuthManager _authManager;
    private readonly LoginViewModel _loginViewModel;

    [ObservableProperty]
    string? firstname;
    [ObservableProperty]
    string? lastname;
    [ObservableProperty]
    string? username;
    [ObservableProperty]
    string? password;

    public SignUpViewModel(AuthManager authManager, LoginViewModel loginViewModel) // DI
    {
        _authManager = authManager;
        _loginViewModel = loginViewModel;
    }

    /// <summary>
    /// This method is called from the OnSigUpClicked event.
    ///
    /// It sends request and parameters to the backend
    /// </summary>
    /// <returns></returns>
    public async Task OnSignUpInvoked()
    {
        if (!string.IsNullOrWhiteSpace(Firstname) && !string.IsNullOrWhiteSpace(Lastname) &&
            !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
        {
            //Send sign up request to Auth Manager
            bool response = await _authManager.HandleSignUpRequest(Firstname, Lastname, Username, Password);

            if (response == true)
            {
                var toast = Toast.Make("User Created Successfully", ToastDuration.Short, 14);
                await toast.Show();

                //Navigate back to the login page
                if (Application.Current?.Windows.Count > 0)
                {
                    Application.Current.Windows[0].Page = new LoginPage(_loginViewModel, this);
                }
            }
            else
            {
                var toast = Toast.Make("Error Signing up, try again!", ToastDuration.Short, 14);
                await toast.Show();
            }
        }
        else
        {
            var toast = Toast.Make("Fill out form", ToastDuration.Short, 14);
            await toast.Show();
        }
    }
}