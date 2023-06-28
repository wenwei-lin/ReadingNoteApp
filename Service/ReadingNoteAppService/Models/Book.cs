using Microsoft.EntityFrameworkCore;

namespace ReadingNoteAppService.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Cover { get; set; }
    public string Publisher { get; set; }
    public DateTime PublishDate { get; set; }
    public string ISBN { get; set; }

    // 导航属性
    public List<Author> Authors { get; set; }
}

// 定义 Book 输入模型
public class BookInputModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Cover { get; set; }
    public string Publisher { get; set; }
    public DateTime PublishDate { get; set; }
    public string ISBN { get; set; }
    public List<string> AuthorNames { get; set; }
}

