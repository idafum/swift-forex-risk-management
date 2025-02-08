using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Risk2.Backend;
using System.Transactions;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;
using Risk2.Data.Models;
using Risk2.Data.Repositories;

namespace Risk2.ViewModels;

public partial class LoginViewModel : ObservableObject
{

    private readonly AuthManager _authManager;

    [ObservableProperty]
    string? username;

    [ObservableProperty]
    string? password;

    /// <summary>
    /// The methos is called from the OnLogicCliked event.
    /// It sends reqeust and parameters to the Backend
    /// </summary>
    /// <returns></returns>
    public async Task OnLogin()
    {
        //Contacts the Auth Manager in the backend
        if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
        {
            //Send request to the auth manager.
            User? user = await _authManager.HandleLoginRequest(Username, Password);
            if (user != null)
            {
                if (Application.Current != null)
                {
                    //Single window application.
                    Application.Current.Windows[0].Page = new AppShell();
                }
                else
                {
                    //Display Error Page.
                    //TODO...
                }

            }
            else
            {
                var toast = Toast.Make("User does not exist", ToastDuration.Short, 14);
                await toast.Show();
            }
        }
        else
        {
            //Display a toast
            string message = "Enter Username an Password";
            ToastDuration duration = ToastDuration.Short;

            var toast = Toast.Make(message, duration, 14);
            await toast.Show();
        }

    }

    public LoginViewModel(AuthManager authManager) //Injected through DI
    {
        _authManager = authManager;
    }

}