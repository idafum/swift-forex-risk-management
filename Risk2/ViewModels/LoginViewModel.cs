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

    private readonly AuthManager authManager;
    private readonly UserRepository _userRepo;
    [ObservableProperty]
    string? username;

    [ObservableProperty]
    string? password;

    public async Task OnLogin()
    {
        //Contacts the Auth Manager in the backend
        if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
        {
            //Send request to the auth manager.
            User? user = await authManager.HandleLoginRequest(Username, Password);
            if (user != null)
            {
                //Navigate to the User account page.
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

    // TODO: Bind Login Data and handle login request
    public LoginViewModel(UserRepository userRepo)
    {
        _userRepo = userRepo;
        authManager = new(_userRepo); //Initialize the Auth manager;
    }

}