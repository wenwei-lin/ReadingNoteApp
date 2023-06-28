namespace ReadingNoteAppService.Models;

public class Tag
{
    public int Id { get; set; }
    public string Title { get; set; }
    
    // 导航属性
    public List<Note> Notes { get; set; }
}

public class TagInputModel
{
    public string Title { get; set; }
}

public class TagOutputModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<int> NoteIds { get; set; }
}