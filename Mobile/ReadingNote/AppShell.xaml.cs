using ReadingNote.Pages;

namespace ReadingNote;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		// 注册BookDetail Page
		Routing.RegisterRoute(nameof(BookDetailPage), typeof(BookDetailPage));
	}
}
