namespace ReadingNoteAppService.Models;

public class Note
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int BookId { get; set; }

    public List<Tag>? Tags { get; set; }
}

public class NoteInputModel
{
    public string Content { get; set; }
    public int BookId { get; set; }
    public List<int>? TagIds { get; set; }
}

public class NoteOutputModel
{
    public int Id { get; set; }
    public string Content { get; set; }
    public int BookId { get; set; }
    public List<int>? TagIds { get; set; }
}