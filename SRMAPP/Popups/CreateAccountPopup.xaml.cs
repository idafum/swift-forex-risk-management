
using CommunityToolkit.Maui.Views;
using SRMAPP.ViewModels;

namespace SRMAPP.Popups;
public partial class CreateAccountPopup : Popup
{
    public CreateAccountPopup(CreateAccountViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}