namespace ReadingNote.Models;

public class UserBook
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public string BookId { get; set; }
    public Book Book { get; set; }
    public ReadingStatus ReadingStatus { get; set; }
    public DateTime CreateTime { get; set; }
}

public enum ReadingStatus
{
    Unread,
    Reading,
    Finished
}
