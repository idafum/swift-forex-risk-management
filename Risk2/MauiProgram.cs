using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Risk2.Data;
using Risk2.Data.Models;
using Risk2.Data.Repositories;
using Risk2.Popups;
using Risk2.ViewModels;
using Risk2.Views;
using SQLite;

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

		//Register Dependencies
		string dbPath = FileAccessHelper.GetLocalFilePath("risk2.db3");
		var connection = new SQLiteAsyncConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex);

		builder.Services.AddSingleton(connection);
		builder.Services.AddSingleton<UserRepository>();
		builder.Services.AddSingleton<DatabaseService>();

		builder.Services.AddSingleton<AccountListPage>();
		builder.Services.AddSingleton<AccountListViewModel>();
		builder.Services.AddTransientPopup<CreateAccountPopup, CreateAccountViewModel>();


#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
