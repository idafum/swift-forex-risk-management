using CommunityToolkit.Maui.Views;
using Risk2.Data.Models;
using Risk2.Popups;
using Risk2.ViewModels;

namespace Risk2.Views;
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