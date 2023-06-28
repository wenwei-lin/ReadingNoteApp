namespace ReadingNote.Models;

public class Note
{
    public string Id { get; set; }
    public string Content { get; set; }
    public ICollection<int> TagIds { get; set; }
    public Book Book { get; set; }

    public ICollection<Tag> Tags { get; set; }
}
