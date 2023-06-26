using ReadingNote.ViewModels;

namespace ReadingNote.Pages;

public partial class BookshelfPage : ContentPage
{
	public BookshelfPage(BookShelfPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}