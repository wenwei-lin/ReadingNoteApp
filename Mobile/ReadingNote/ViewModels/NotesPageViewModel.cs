using CommunityToolkit.Mvvm.ComponentModel;
using ReadingNote.Models;
using ReadingNote.Services;
using System.Collections.ObjectModel;

namespace ReadingNote.ViewModels;

public partial class NotesPageViewModel : ObservableObject
{
    private readonly INoteService noteService;

    [ObservableProperty]
    ObservableCollection<Note> notes;

    public NotesPageViewModel(INoteService noteService)
    {
        notes = new ObservableCollection<Note>();
        this.noteService = noteService;
        LoadData();
    }

    void LoadData()
    {
        var allNotes = noteService.GetNotes();
        foreach (var note in allNotes)
        {
            Notes.Add(note);
        }
    }
}
