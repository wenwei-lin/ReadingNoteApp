namespace ReadingNote.Models;

public class Note
{
    public int Id { get; set; }
    public string Content { get; set; }
    public ICollection<int> TagIds { get; set; }
    public int BookId { get; set; }
    
    // Book is a navigation property
    public Book Book { get; set; }
    public ICollection<Tag> Tags { get; set; }
}
