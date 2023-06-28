using CommunityToolkit.Mvvm.ComponentModel;
using ReadingNote.Models;
using ReadingNote.Services;
using System.Collections.ObjectModel;

namespace ReadingNote.ViewModels;

public partial class BooklistsPageViewModel : ObservableObject
{
    private readonly DataManager dataManager;

    [ObservableProperty]
    ObservableCollection<Booklist> booklists;

    public BooklistsPageViewModel(IBooklistService booklistService)
    {
        Booklists = new ObservableCollection<Booklist>();
        this.booklistService = booklistService;
        LoadData();
    }

    void LoadData()
    {
        Booklists.Clear();
        foreach (var booklist in booklistService.GetBooklists())
        {
            Booklists.Add(booklist);
        }
    }

}
