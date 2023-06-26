namespace ReadingNote.Models;

public class UserBook
{
    public string Id { get; set; }
    public Book Book { get; set; }
    public ReadingStatus ReadingStatus { get; set; }
    public int TotalNotes { get; set; }
    // public DateTime CreateTime { get; set; }

    public UserBook(string id, Book book, ReadingStatus readingStatus, int totalNotes)
    {
        Id = id;
        Book = book;
        ReadingStatus = readingStatus;
        TotalNotes = totalNotes;
    }
}

public enum ReadingStatus
{
    Unread,
    Reading,
    Finished
}
