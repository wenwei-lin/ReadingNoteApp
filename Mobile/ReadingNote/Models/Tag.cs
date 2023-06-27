namespace ReadingNote.Models;

public class Tag
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string UserId { get; set; }

    public Tag(string id, string title)
    {
        Id = id;
        Title = title;
    }
}
