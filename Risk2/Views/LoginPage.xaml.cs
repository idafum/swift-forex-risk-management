using Risk2.ViewModels;

namespace Risk2.Views;

public partial class LoginPage : ContentPage
{
    private readonly LoginViewModel _loginViewModel;
    private readonly SignUpViewModel _signUpViewModel;
    public LoginPage(LoginViewModel loginViewModel, SignUpViewModel signUpViewModel) //Resolved DI
    {
        InitializeComponent();

        _loginViewModel = loginViewModel;
        _signUpViewModel = signUpViewModel;

        BindingContext = _loginViewModel; //Set the binding context
    }

    /// <summary>
    /// This event is invoked when the 'sign up now' label is clicked
    /// 
    /// The current window is replaced with the Sign Up Page
    /// </summary>
    /// <param name="sender"> Label control </param>
    /// <param name="args"></param>
    private void OnTapGestureRecognizerTapped(object sender, TappedEventArgs args)
    {
        if (Application.Current?.Windows.Count > 0)
        {
            Application.Current.Windows[0].Page = new SignUpPage(_signUpViewModel);
        }
    }

    /// <summary>
    /// Event Handler
    /// Invoked when the Login button is clicked
    /// 
    /// It calls the OnLogin in the view model
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private async void OnLoginClicked(object sender, EventArgs args)
    {

        await _loginViewModel.OnLogin();
    }
}