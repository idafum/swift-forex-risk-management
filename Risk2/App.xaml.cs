using Risk2.Data.Repositories;
using Risk2.Views;

namespace Risk2;

public partial class App : Application
{
	public static UserRepository? UserRepo { get; private set; }
	public App(UserRepository repo) //DI automatically populated the repo parameter to the constructor
	{
		InitializeComponent();
		UserRepo = repo;
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new LoginPage()); //Starts at login page
	}
}