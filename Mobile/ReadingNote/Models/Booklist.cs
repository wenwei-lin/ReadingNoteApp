namespace ReadingNote.Models;

public class Booklist
{
    public string Id { get; set; }
    public string Title { get; set; }
    public ICollection<Book> Books { get; set; }
    public string UserId { get; set; }
    public DateTime CreateTime { get; set; }
}