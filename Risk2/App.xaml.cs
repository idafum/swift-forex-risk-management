using Risk2.Views;

namespace Risk2;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new LoginPage()); //Starts at login page
	}
}