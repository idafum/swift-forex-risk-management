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