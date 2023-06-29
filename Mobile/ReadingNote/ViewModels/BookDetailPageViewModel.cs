using CommunityToolkit.Mvvm.ComponentModel;
using ReadingNote.Models;
using ReadingNote.Services;

namespace ReadingNote.ViewModels;

[QueryProperty(nameof(Id), nameof(Id))]
public partial class BookDetailPageViewModel : ObservableObject
{
    private readonly DataManager dataManager;
    public int Id { get; set; }

    [ObservableProperty]
    Book book;

    public BookDetailPageViewModel(DataManager dataManager)
    {
        this.dataManager = dataManager;
    }

    public async Task LoadDataAsync()
    {
        var book = await dataManager.GetBookAsync(Id, true);
        Book = book;
    }
}
