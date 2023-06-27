using CommunityToolkit.Mvvm.ComponentModel;
using ReadingNote.Models;
using ReadingNote.Services;
using System.Collections.ObjectModel;

namespace ReadingNote.ViewModels;

public partial class BookShelfPageViewModel : ObservableObject
{
    private readonly IUserBookService userBookService;

    [ObservableProperty]
    ObservableCollection<UserBook> userBooks;

    public BookShelfPageViewModel(IUserBookService userBookService)
    {
        UserBooks = new ObservableCollection<UserBook>();
        this.userBookService = userBookService;
        LoadData();
    }

    
    void LoadData()
    {
        var userBooks = userBookService.GetUserBooks();
        UserBooks.Clear();
        foreach (var userBook in userBooks)
        {
            UserBooks.Add(userBook);
        }
    }

}
