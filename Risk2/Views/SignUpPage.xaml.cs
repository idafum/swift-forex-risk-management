
using Risk2.ViewModels;

namespace Risk2.Views;

public partial class SignUpPage : ContentPage
{
    private readonly SignUpViewModel _signUpViewModel;
    public SignUpPage(SignUpViewModel signUpViewModel) //DI
    {
        InitializeComponent();

        _signUpViewModel = signUpViewModel;

        BindingContext = _signUpViewModel; //Set the Binding Context
    }

    /// <summary>
    /// Event Handler
    /// Fires with the SignUp button is clicked
    /// 
    /// It calls the OnSignUpInvoked in the view model
    /// </summary>
    /// <param name="sender">Button control</param>
    /// <param name="eventArgs"></param>
    private async void OnSignUpClicked(object sender, EventArgs eventArgs)
    {
        await _signUpViewModel.OnSignUpInvoked();
    }
}