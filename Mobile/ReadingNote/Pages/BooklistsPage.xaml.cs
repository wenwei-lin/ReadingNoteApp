using ReadingNote.ViewModels;

namespace ReadingNote.Pages;

public partial class BooklistsPage : ContentPage
{
	public BooklistsPage(BooklistsPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}