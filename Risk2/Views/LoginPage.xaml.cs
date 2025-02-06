using System.Threading.Tasks;
using Risk2.ViewModels;

namespace Risk2.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = new LoginViewModel(); //Set the binding context
    }

    /// <summary>
    /// This event is invoked when the 'sign up now' label is clicked
    /// 
    /// The current window is replaced with the Sign Up Page
    /// </summary>
    /// <param name="sender"> Label control </param>
    /// <param name="args"></param>
    void OnTapGestureRecognizerTapped(object sender, TappedEventArgs args)
    {
        if (Application.Current?.Windows.Count > 0)
        {
            Application.Current.Windows[0].Page = new SignUpPage();
        }
    }
}