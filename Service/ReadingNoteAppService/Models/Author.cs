using Microsoft.EntityFrameworkCore;

namespace ReadingNoteAppService.Models;

public class Author
{
    public int Id { get; set; }
    public string ChineseName { get; set; }
    public string? OriginalName { get; set; }
    public string? Description { get; set; }
    public string? Avatar { get; set; }

    public List<Book> Books { get; set; }
}

public class AuthorInputModel
{
    public string ChineseName { get; set; }
    public string? OriginalName { get; set; }
    public string? Description { get; set; }
    public string? Avatar { get; set; }
}   