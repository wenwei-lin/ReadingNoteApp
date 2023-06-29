using ReadingNote.ViewModels;

namespace ReadingNote.Pages;

public partial class BookDetailPage : ContentPage
{
    private BookDetailPageViewModel viewModel => BindingContext as BookDetailPageViewModel;
	public BookDetailPage(BookDetailPageViewModel vm)
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