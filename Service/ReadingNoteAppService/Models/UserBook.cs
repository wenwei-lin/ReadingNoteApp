using Microsoft.EntityFrameworkCore;

namespace ReadingNoteAppService.Models;

public class UserBook
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int BookId { get; set; }
    public ReadingStatus ReadingStatus { get; set; }

    // 导航属性
    public User User { get; set; }
    public Book Book { get; set; }
}

public enum ReadingStatus
{
    Unread,
    Reading,
    Finished
}
