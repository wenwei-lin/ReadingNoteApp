using ReadingNote.ViewModels;

namespace ReadingNote.Pages;

public partial class HomePage : ContentPage
{
    private HomePageViewModel viewModel => BindingContext as HomePageViewModel;
    public HomePage(HomePageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	override protected async void OnAppearing()
	{
        base.OnAppearing();
        await viewModel.LoadDataAsync();
    }
}