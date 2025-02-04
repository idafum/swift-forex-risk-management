
using CommunityToolkit.Maui.Views;
using Risk2.ViewModels;

namespace Risk2.Popups;
public partial class CreateAccountPopup : Popup
{
    public CreateAccountPopup(CreateAccountViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}