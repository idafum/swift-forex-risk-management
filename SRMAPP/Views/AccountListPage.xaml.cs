using CommunityToolkit.Maui.Views;
using SRMAPP.Popups;
using SRMAPP.ViewModels;

namespace SRMAPP.Views;
public partial class AccountListPage : ContentPage
{
    public AccountListPage(AccountListViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}