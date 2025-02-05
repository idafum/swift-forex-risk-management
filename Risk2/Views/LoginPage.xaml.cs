using System.Threading.Tasks;
using Risk2.ViewModels;

namespace Risk2.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = new LoginViewModel();
    }

    void OnTapGestureRecognizerTapped(object sender, TappedEventArgs args)
    {
        //Change text color
        Label? label = sender as Label;

        if (label != null)
            label.TextColor = Colors.Blue;


        if (Application.Current?.Windows.Count > 0)
        {
            Application.Current.Windows[0].Page = new SignUpPage();
        }
    }
}