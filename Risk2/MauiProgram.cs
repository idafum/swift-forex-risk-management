using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Risk2.Data;
using Risk2.Data.Repositories;
using Risk2.Popups;
using Risk2.ViewModels;
using Risk2.Views;

namespace Risk2;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		string dbPath = FileAccessHelper.GetLocalFilePath("user.db3");
		builder.Services.AddSingleton<UserRepository>(s => ActivatorUtilities.CreateInstance<UserRepository>(s, dbPath));


		builder.Services.AddSingleton<AccountListPage>();
		builder.Services.AddSingleton<AccountListViewModel>();
		builder.Services.AddTransientPopup<CreateAccountPopup, CreateAccountViewModel>();


#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
