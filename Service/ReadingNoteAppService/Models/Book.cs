using Microsoft.EntityFrameworkCore;

namespace ReadingNoteAppService.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public string? Cover { get; set; }

    // 导航属性
    public List<Note>? Notes { get; set; }
}

public class BookInputModel
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public string? Cover { get; set; }
}

public class BookOutputModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public string? Cover { get; set; }
    public List<int>? NoteIds { get; set; }
}

