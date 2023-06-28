using ReadingNote.ViewModels;

namespace ReadingNote.Pages;

public partial class BookshelfPage : ContentPage
{
    private BookShelfPageViewModel viewModel => BindingContext as BookShelfPageViewModel;
    public BookshelfPage(BookShelfPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
		await viewModel.LoadDataAsync();
    }
}