using CommunityToolkit.Mvvm.ComponentModel;
using ReadingNote.Models;
using System.Collections.ObjectModel;

namespace ReadingNote.ViewModels;

public partial class HomePageViewModel: ObservableObject
{
    public HomePageViewModel()
    {
        recentBooks = new ObservableCollection<Book>();
        recentNotes = new ObservableCollection<Note>();
    }

    [ObservableProperty]
    ObservableCollection<Book> recentBooks;

    [ObservableProperty]
    ObservableCollection<Note> recentNotes;
    
}