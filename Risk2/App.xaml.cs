using Risk2.Data.Repositories;
using Risk2.Views;
using Risk2.Data;
using Risk2.ViewModels;
using System.Diagnostics;

namespace Risk2;

public partial class App : Application
{
	private readonly IServiceProvider _services;
	public App(IServiceProvider services)
	{
		InitializeComponent();
		_services = services;
		DatabaseService? databaseService = _services.GetService<DatabaseService>();

		if (databaseService == null)
		{
			Debug.WriteLine($"[App Error] Missing dependencies. Application will exit.");

			//Gracefully shut down the app
			Environment.Exit(1); //Terminate the app.
		}
		else
		{
			Task.Run(async () =>
			{
				bool isSuccess = await databaseService.InitAsync();
				if (!isSuccess)
				{
					Environment.Exit(1); //Shut down the app gracefully
				}
			});
		}
	}


	protected override Window CreateWindow(IActivationState? activationState)
	{
		try
		{
			LoginViewModel loginViewModel = _services.GetRequiredService<LoginViewModel>();
			SignUpViewModel signUpViewModel = _services.GetRequiredService<SignUpViewModel>(); ;

			return new Window(new LoginPage(loginViewModel, signUpViewModel)); //Starts at login page
		}
		catch (Exception ex)
		{
			Debug.WriteLine($"[App Error] Missing dependencies: {ex.Message}");

			//Redirect to an error page instead of crashing.
			//TODO.
			//Create Error page.
			return new Window();
		}

	}
}