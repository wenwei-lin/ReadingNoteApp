using CommunityToolkit.Mvvm.ComponentModel;
using ReadingNote.Models;
using ReadingNote.Services;
using System.Collections.ObjectModel;

namespace ReadingNote.ViewModels;

public partial class BookShelfPageViewModel : ObservableObject
{
    private readonly DataManager dataManager;

    [ObservableProperty]
    ObservableCollection<Book> books;

    public BookShelfPageViewModel(DataManager dataManager)
    {
        books = new ObservableCollection<Book>();
        this.dataManager = dataManager;
    }


    public async Task LoadDataAsync()
    {
        var books = await dataManager.GetAllBooksAsync();
        foreach (var book in books)
        {
            Books.Add(book);
        }
    }

}
