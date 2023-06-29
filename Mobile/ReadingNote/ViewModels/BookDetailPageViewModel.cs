using CommunityToolkit.Mvvm.ComponentModel;
using ReadingNote.Models;
using ReadingNote.Services;
using System.Collections.ObjectModel;

namespace ReadingNote.ViewModels;

[QueryProperty(nameof(Id), nameof(Id))]
public partial class BookDetailPageViewModel : ObservableObject
{
    private readonly DataManager dataManager;
    public int Id { get; set; }

    [ObservableProperty]
    Book book;

    // 记录已有Tag
    [ObservableProperty]
    ObservableCollection<Tag> tags;

    [ObservableProperty]
    Note newNote;

    [ObservableProperty]
    Tag newTag;

    [ObservableProperty]
    ObservableCollection<Tag> newTags;

    public BookDetailPageViewModel(DataManager dataManager)
    {
        this.dataManager = dataManager;
        tags = new ObservableCollection<Tag>();
        newTags = new ObservableCollection<Tag>();
        newNote = new Note();
        newTag = new Tag();
    }

    public async Task LoadDataAsync()
    {
        var book = await dataManager.GetBookAsync(Id, true);
        Book = book;
    }
}
