using ReadingNote.ViewModels;

namespace ReadingNote.Pages;

public partial class HomePage : ContentPage
{
	public HomePage(HomePageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}