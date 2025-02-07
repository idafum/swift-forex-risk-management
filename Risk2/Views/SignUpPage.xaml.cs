
using Risk2.ViewModels;

namespace Risk2.Views;

public partial class SignUpPage : ContentPage
{
    private readonly SignUpViewModel? _signUpViewModel;
    private readonly IServiceProvider _service;
    public SignUpPage(IServiceProvider serviceProvider) //DI
    {
        InitializeComponent();
        _service = serviceProvider;

        //Explicit Dependency resolution
        _signUpViewModel = _service.GetService<SignUpViewModel>();
        BindingContext = _signUpViewModel; //Set the Binding Context
    }

    /// <summary>
    /// Event Handler
    /// Fires with the SignUp button is clicked
    /// 
    /// It calls the OnSignUpInvoked in the view model
    /// </summary>
    /// <param name="sender">Button control</param>
    /// <param name="eventArgs"></param>
    private async void OnSignUpClicked(object sender, EventArgs eventArgs)
    {
        await _signUpViewModel.OnSignUpInvoked();
    }
}