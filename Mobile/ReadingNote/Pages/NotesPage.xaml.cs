using ReadingNote.ViewModels;

namespace ReadingNote.Pages;

public partial class NotesPage : ContentPage
{
	public NotesPage(NotesPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}