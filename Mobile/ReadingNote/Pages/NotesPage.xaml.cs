using ReadingNote.ViewModels;

namespace ReadingNote.Pages;

public partial class NotesPage : ContentPage
{
    private NotesPageViewModel viewModel => BindingContext as NotesPageViewModel;
    public NotesPage(NotesPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		await viewModel.LoadDataAsync();
    }

}