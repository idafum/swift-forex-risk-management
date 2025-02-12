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

    /// <summary>
    /// Event Handler
    /// Fired when list item is swiped right.
    /// 
    /// It calls the OnDeleteAccountInvoked in the view model
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void OnDeleteAccount(object sender, EventArgs e)
    {
        if (sender is SwipeItem swipeItem && swipeItem.BindingContext is AccountViewModel accountView)
        {
            await _viewModel.OnDeleteAccountInvoked(accountView);
        }
    }
}