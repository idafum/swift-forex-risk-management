using Risk2.Data.Repositories;
using Risk2.Views;
using Risk2.Data;
using Risk2.ViewModels;

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
			//TODO
			//Display Error and End app.
		}
		else
		{
			databaseService.InitializeAsync().Wait(); //Call the Init database methods
		}
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new LoginPage(_services)); //Starts at login page
	}
}