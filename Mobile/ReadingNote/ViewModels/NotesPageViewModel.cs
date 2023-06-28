using CommunityToolkit.Mvvm.ComponentModel;
using ReadingNote.Models;
using ReadingNote.Services;
using System.Collections.ObjectModel;

namespace ReadingNote.ViewModels;

public partial class NotesPageViewModel : ObservableObject
{
    private readonly DataManager dataManager;

    [ObservableProperty]
    ObservableCollection<Note> notes;

    public NotesPageViewModel(DataManager dataManager)
    {
        notes = new ObservableCollection<Note>();
        this.dataManager = dataManager;
    }

    public async Task LoadDataAsync()
    {
        var notes = await dataManager.GetAllNotesAsync();
        foreach (var note in notes)
        {
            Notes.Add(note);
        }
    }
}
