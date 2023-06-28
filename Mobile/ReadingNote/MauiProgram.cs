using Microsoft.Extensions.Logging;
using CommunityToolkit.Mvvm;
using ReadingNote.Services;
using Microsoft.Extensions.DependencyInjection;
using ReadingNote.Pages;
using ReadingNote.ViewModels;
using System.Net.Http.Headers;

namespace ReadingNote;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
       

		// Service dependencies
		builder.Services.AddSingleton<DataManager>();

		// ViewModels dependencies
		builder.Services.AddSingleton<BookshelfPage>();
		builder.Services.AddSingleton<BookShelfPageViewModel>();
		builder.Services.AddSingleton<HomePage>();
		builder.Services.AddSingleton<HomePageViewModel>();
		builder.Services.AddSingleton<NotesPage>();
		builder.Services.AddSingleton<NotesPageViewModel>();
		builder.Services.AddSingleton<BooklistsPage>();
		builder.Services.AddSingleton<BooklistsPageViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
