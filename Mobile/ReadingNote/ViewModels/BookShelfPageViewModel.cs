using CommunityToolkit.Mvvm.ComponentModel;
using ReadingNote.Models;
using ReadingNote.Services;
using System.Collections.ObjectModel;

namespace ReadingNote.ViewModels;

public partial class BookShelfPageViewModel : ObservableObject
{
    private readonly DataManager dataManager;

    // 使用ViewModel的属性来绑定View
    [ObservableProperty]
    ObservableCollection<BookViewModel> books;

    public BookShelfPageViewModel(DataManager dataManager)
    {
        books = new ObservableCollection<BookViewModel>();
        this.dataManager = dataManager;
    }


    public async Task LoadDataAsync()
    {
        Books.Clear();
        var books = await dataManager.GetAllBooksAsync();

        // 将Book转换为BookViewModel
        foreach (var book in books)
        {
            var bookVM = new BookViewModel(book);
            Books.Add(bookVM);
        }
    }

}
