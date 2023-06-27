using ReadingNote.Models;

namespace ReadingNote.Services;

public class MoceBooklistService : IBooklistService
{
    public ICollection<Booklist> GetBooklists()
    {
        List<Booklist> booklists = new List<Booklist>
        {
            new Booklist("1", 
                "意识流小说",
                new List<Book>{ new Book("1", "尤利西斯", "s10389470"), new Book("5", "洛丽塔", "s32299170"), new Book("10", "达洛卫夫人", "s34300732") }
            ),
            new Booklist(
                "2",
                "如何阅读？",
                new List<Book> { new Book("2", "如何阅读一本书", "s1670978"), new Book("11", "卡片笔记写作法", "s33927783"), new Book("4", "文学讲稿", "s29767494") }
            )
        };

        return booklists;
    }
}
