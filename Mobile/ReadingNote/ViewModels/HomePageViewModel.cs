using CommunityToolkit.Mvvm.ComponentModel;
using ReadingNote.Models;
using ReadingNote.Services;
using System.Collections.ObjectModel;

namespace ReadingNote.ViewModels;

public partial class HomePageViewModel: ObservableObject
{
    private readonly IUserBookService userBookService;
    private readonly INoteService noteService;

    [ObservableProperty]
    ObservableCollection<Book> recentBooks;

    [ObservableProperty]
    ObservableCollection<Note> recentNotes;

    public HomePageViewModel(IUserBookService ubs, INoteService ns)
    {
        recentBooks = new ObservableCollection<Book>();
        recentNotes = new ObservableCollection<Note>();
        userBookService = ubs;
        noteService = ns;
        LoadData();
    }

    void LoadData()
    {
        List<Book> books = userBookService.GetRecentUserBooks(3).Select(ub => ub.Book).ToList();
        List<Note> notes = noteService.GetRecentNotes(3).ToList();

        RecentBooks.Clear();
        RecentNotes.Clear();

        foreach (var book in books)
        {
            RecentBooks.Add(book);
        }

        foreach (var note in notes)
        {
            RecentNotes.Add(note);
        }
    }
    
   
}