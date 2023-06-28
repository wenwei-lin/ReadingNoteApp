namespace ReadingNote.Models;

public class Tag
{
    public string Id { get; set; }
    public string Title { get; set; }
    public ICollection<int> NoteIds { get; set; }

    public ICollection<Note> Notes { get; set; }

}
