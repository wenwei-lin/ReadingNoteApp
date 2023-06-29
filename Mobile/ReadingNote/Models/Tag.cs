namespace ReadingNote.Models;

public class Tag
{
    public int? Id { get; set; }
    public string Title { get; set; }
    public ICollection<int> NoteIds { get; set; }
}
