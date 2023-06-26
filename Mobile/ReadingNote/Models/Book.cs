namespace ReadingNote.Models;

public class Book
{
    public string Id { get; set; }
    public string Title { get; set; }
    public ICollection<Author> Authors { get; set; }
    public ICollection<Author> Translators { get; set; }
    public string Publisher { get; set; }
    public string ISBN { get; set; }
    public string Cover { get; set; }
    public string Description { get; set; }

    public Book(string id, string title, string cover)
    {
        Id = id;
        Title = title;
        Cover = cover;
    }
}