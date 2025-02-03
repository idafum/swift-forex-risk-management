using CommunityToolkit.Maui.Views;
using SRMAPP.Model;
using SRMAPP.Popups;
using SRMAPP.ViewModels;

namespace SRMAPP.Views;
public partial class AccountListPage : ContentPage
{
    private AccountListViewModel _viewModel;
    public AccountListPage(AccountListViewModel vm)
    {

        InitializeComponent();
        _viewModel = vm;
        BindingContext = _viewModel;
    }

    private void OnDeleteAccount(object sender, EventArgs e)
    {
        if (sender is SwipeItem swipeItem && swipeItem.BindingContext is Account account)
        {
            _viewModel.DeleteCommand.Execute(account);
        }
    }
}