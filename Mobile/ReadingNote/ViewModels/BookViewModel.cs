using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ReadingNote.Models;
using ReadingNote.Pages;

namespace ReadingNote.ViewModels;

public partial class BookViewModel : ObservableObject
{
    [ObservableProperty]
    Book book;

    // 通过构造器注入Book
    public BookViewModel(Book book)
    {
        Book = book;
    }

    [RelayCommand]
    Task NavigateToDetail() => Shell.Current.GoToAsync($"{nameof(BookDetailPage)}?Id={Book.Id}");
}
