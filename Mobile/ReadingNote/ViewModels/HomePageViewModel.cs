using CommunityToolkit.Mvvm.ComponentModel;
using ReadingNote.Models;
using ReadingNote.Services;
using System.Collections.ObjectModel;

namespace ReadingNote.ViewModels;

public partial class HomePageViewModel: ObservableObject
{
    private readonly DataManager dataManager;

    [ObservableProperty]
    ObservableCollection<Book> recentBooks;

    [ObservableProperty]
    ObservableCollection<Note> recentNotes;

    public HomePageViewModel(DataManager dataManager)
    {
        recentBooks = new ObservableCollection<Book>();
        recentNotes = new ObservableCollection<Note>();
        this.dataManager = dataManager;
    }
    
    public async Task LoadDataAsync()
    {
        var books = await dataManager.GetAllBooksAsync();
        var notes = await dataManager.GetAllNotesAsync();
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