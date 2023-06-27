using Microsoft.Extensions.Logging;
using CommunityToolkit.Mvvm;
using ReadingNote.Services;
using Microsoft.Extensions.DependencyInjection;
using ReadingNote.Pages;
using ReadingNote.ViewModels;

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
		builder.Services.AddSingleton<IUserBookService, MockUserBookService>();
		builder.Services.AddSingleton<INoteService, MockNoteService>();
		builder.Services.AddSingleton<IBooklistService, MoceBooklistService>();

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
