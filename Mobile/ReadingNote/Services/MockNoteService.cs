using ReadingNote.Models;

namespace ReadingNote.Services;

public class MockNoteService : INoteService
{
    public ICollection<Note> GetNotes()
    {
        List<Note> notes = new List<Note>
        {
            new Note("1", 
                "阅读时请思考这四个问题：1. 整体来说，这本书到底在谈些什么；2. 作者细部说了些什么，怎么说的？3. 这本书说得有道理吗？是全部有道理，还是部分有道理？4. 这本书跟你有什么关系？", 
                "54页", 
                new List<Tag> {new Tag("1", "阅读")},
                new Book("2", "如何阅读一本书", "s1670978"),
                new DateTime(2023, 6, 22)
            ),
            new Note("2",
                "卢曼有两种卡片盒：文献卡片盒和主卡片盒，他们的使用方法如下：1. 阅读书籍、文献，记录简短的笔记并放入文献卡片盒；2. 回顾文献卡片盒内的笔记，将与自己思考或写作相关的内容写在新的卡片上，放入主卡片盒。",
                "54-55页",
                new List<Tag> {new Tag("2", "读书笔记"), new Tag("1", "阅读")},
                new Book("11", "卡片笔记写作法", "s33927783"),
                new DateTime(2023, 6, 22)
            ),
            new Note("3",
                "电视、收音机等大众传媒的信息都进过包装，使得听众可以毫不费力的消化信息，不用做出自己的结论。",
                "10页",
                new List<Tag> {new Tag("3", "大众传媒")},
                new Book("2", "如何阅读一本书", "s1670978"),
                new DateTime(2023, 6, 23)
            ),
            new Note("4",
                "获取信息的方式有两种：口头和书面文字。对于想要增进智慧的人来说，阅读是必要的。",
                "9页",
                new List<Tag> {new Tag("3", "大众传媒")},
                new Book("2", "如何阅读一本书", "s1670978"),
                new DateTime(2023, 6, 24)
            ),

        };

        return notes;
    }

    public ICollection<Note> GetRecentNotes(int count)
    {
        List<Note> notes = new List<Note>
        {
            new Note("1",
                "阅读时请思考这四个问题：1. 整体来说，这本书到底在谈些什么；2. 作者细部说了些什么，怎么说的？3. 这本书说得有道理吗？是全部有道理，还是部分有道理？4. 这本书跟你有什么关系？",
                "54页",
                new List<Tag> {new Tag("1", "阅读")},
                new Book("2", "如何阅读一本书", "s1670978"),
                new DateTime(2023, 6, 22)
            ),
            new Note("2",
                "卢曼有两种卡片盒：文献卡片盒和主卡片盒，他们的使用方法如下：1. 阅读书籍、文献，记录简短的笔记并放入文献卡片盒；2. 回顾文献卡片盒内的笔记，将与自己思考或写作相关的内容写在新的卡片上，放入主卡片盒。",
                "54-55页",
                new List<Tag> {new Tag("2", "读书笔记"), new Tag("1", "阅读")},
                new Book("11", "卡片笔记写作法", "s33927783"),
                new DateTime(2023, 6, 22)
            ),
            new Note("3",
                "电视、收音机等大众传媒的信息都进过包装，使得听众可以毫不费力的消化信息，不用做出自己的结论。",
                "10页",
                new List<Tag> {new Tag("3", "大众传媒")},
                new Book("2", "如何阅读一本书", "s1670978"),
                new DateTime(2023, 6, 23)
            ),
            new Note("4",
                "获取信息的方式有两种：口头和书面文字。对于想要增进智慧的人来说，阅读是必要的。",
                "9页",
                new List<Tag> {new Tag("3", "大众传媒")},
                new Book("2", "如何阅读一本书", "s1670978"),
                new DateTime(2023, 6, 24)
            ),

        };

        return notes.GetRange(0, count);
    }
}
