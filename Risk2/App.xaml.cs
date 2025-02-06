using Risk2.Data.Repositories;
using Risk2.Views;
using Risk2.Data;

namespace Risk2;

public partial class App : Application
{
	public App(DatabaseService databaseService)
	{
		InitializeComponent();
		Task.Run(async () => await databaseService.InitializeAsync()).Wait();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new LoginPage()); //Starts at login page
	}
}