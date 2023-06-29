using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ReadingNote.Models;
using ReadingNote.Services;
using System.Collections.ObjectModel;

namespace ReadingNote.ViewModels;

public partial class NotesPageViewModel : ObservableObject
{
    private readonly DataManager dataManager;

    // 记录已有Tag
    [ObservableProperty]
    ObservableCollection<Tag> tags;

    [ObservableProperty]
    ObservableCollection<Note> notes;

    [ObservableProperty]
    ObservableCollection<Book> books;

    [ObservableProperty]
    Note newNote;

    [ObservableProperty]
    Tag newTag;

    [ObservableProperty]
    ObservableCollection<Tag> newTags;

    public NotesPageViewModel(DataManager dataManager)
    {
        notes = new ObservableCollection<Note>();
        books = new ObservableCollection<Book>();
        tags = new ObservableCollection<Tag>();
        newTags = new ObservableCollection<Tag>();
        newNote = new Note();
        newTag = new Tag();

        this.dataManager = dataManager;
    }

    public async Task LoadDataAsync()
    {
        Notes.Clear();
        Books.Clear();
        Tags.Clear();
        NewTags.Clear();
        NewNote = new Note();
        NewTag = new Tag();

        var notes = await dataManager.GetAllNotesAsync();
        foreach (var note in notes)
        {
            Notes.Add(note);
        }

        var books = await dataManager.GetAllBooksAsync();
        foreach (var book in books)
        {
            Books.Add(book);
        }

        var tags = await dataManager.GetAllTagsAsync();
        foreach (var tag in tags)
        {
            Tags.Add(tag);
        }
    }

    [RelayCommand]
    void AddTag()
    {
        if (string.IsNullOrEmpty(NewTag.Title))
        {
            return;
        }

        // 查询Tags中是否有标题一致的，如果有：给NewTag添加Id
        foreach (var tag in Tags)
        {
            if (tag.Title.Equals(NewTag.Title))
            {
                NewTag.Id = tag.Id;
                break;
            }
        }

        NewTags.Add(NewTag);
        NewTag = new Tag();
    }

    [RelayCommand]
    void RemoveTag(Tag tag)
    {
        NewTags.Remove(tag);
    }

    [RelayCommand]
    async void AddNote()
    {
        // 将没有Id的Tag添加到数据库，并将得到的Id赋值给类
        foreach (var tag in NewTags)
        {
            if (tag.Id == null)
            {
                var addedTag = await dataManager.AddTagAsync(tag);
                tag.Id = addedTag.Id;
            }
        }

        NewNote.Tags = NewTags;

        // 添加Note到数据库
        var addedNote = await dataManager.AddNoteAsync(NewNote);

        // Refresh page
        await LoadDataAsync();
    }

    [RelayCommand]
    async void DeleteNote(Note note)
    {
        // Delete note
        await dataManager.DeleteNoteAsync(note);

        // Load Page
        Notes.Remove(note);
    }
}
