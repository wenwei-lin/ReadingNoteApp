namespace ReadingNote.Models;

public class Note
{
    public string Id { get; set; }
    public string Content { get; set; }
    public string PageLocation { get; set; }
    public ICollection<Tag> Tags { get; set; }
    // public string UserId { get; set; }
    public string BookId { get; set; }
    public Book Book { get; set; }
    public DateTime CreateTime { get; set; }
    public DateTime LastEditTime { get; set;}

    public Note(string id, string content , string pageLocation, ICollection<Tag> tags, Book book, DateTime lastEditTime)
    {
        Id = id;
        Content = content;
        PageLocation = pageLocation;
        Tags = tags;
        Book = book;
        LastEditTime = lastEditTime;
    }
}
