using System.Threading.Tasks;
using System.Xml.Serialization;
using Risk2.ViewModels;

namespace Risk2.Views;

public partial class LoginPage : ContentPage
{
    private readonly LoginViewModel _vm;
    public LoginPage(LoginViewModel vm)
    {
        InitializeComponent();
        _vm = vm;
        BindingContext = _vm; //Set the binding context
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
            Application.Current.Windows[0].Page = new SignUpPage(_vm);
        }
    }

    /// <summary>
    /// Evenh Handler
    /// Invoked when the Login button is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private async void OnLoginClicked(object sender, EventArgs args)
    {
        await _vm.OnLogin();
    }
}