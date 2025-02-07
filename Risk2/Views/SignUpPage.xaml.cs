using Risk2.ViewModels;

namespace Risk2.Views;

public partial class SignUpPage : ContentPage
{
    private readonly LoginViewModel _loginViewModel;
    public SignUpPage(LoginViewModel loginViewModel) //DI
    {
        InitializeComponent();
        _loginViewModel = loginViewModel;

        BindingContext = new SignUpViewModel(); //Set the Binding Context

    }

    /// <summary>
    /// This method is invoked when the 'Sign Up' Button is clicked
    /// 
    /// Its sends creat account request to the backend.
    /// If successfull, navigate back to the login screen
    /// else 'username' already exists'
    /// </summary>
    /// <param name="sender">Button control</param>
    /// <param name="eventArgs"></param>
    private void OnSignUpClicked(object sender, EventArgs eventArgs)
    {

        //TODO..
        //MVP: Navigate back to the login 
        if (Application.Current?.Windows.Count > 0)
        {
            Application.Current.Windows[0].Page = new LoginPage(_loginViewModel); //DI used here.
        }
    }
}