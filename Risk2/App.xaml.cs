using Risk2.Data.Repositories;
using Risk2.Views;
using Risk2.Data;
using Risk2.ViewModels;

namespace Risk2;

public partial class App : Application
{
	private readonly IServiceProvider _services;
	public App(DatabaseService databaseService, IServiceProvider services)
	{
		InitializeComponent();
		_services = services;
		Task.Run(async () => await databaseService.InitializeAsync()).Wait(); //Initialize Database
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		var loginViewModel = _services.GetRequiredService<LoginViewModel>();

		return new Window(new LoginPage(loginViewModel)); //Starts at login page
	}
}