using Microsoft.EntityFrameworkCore;

namespace ReadingNoteAppService.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    // 导航属性
    public List<UserBook> UserBooks { get; set; }
}
