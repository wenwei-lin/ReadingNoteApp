using ReadingNote.Models;

namespace ReadingNote.Services;

public class MockUserBookService : IUserBookService
{
    public ICollection<UserBook> GetRecentUserBooks(int count)
    {
        List<UserBook> UserBooks = new List<UserBook>
        {
            new UserBook("1", new Book("1", "尤利西斯", "s10389470"), ReadingStatus.Unread, 0),
            new UserBook("2", new Book("2", "如何阅读一本书", "s1670978"), ReadingStatus.Reading, 10),
            new UserBook("3", new Book("3", "婚变", "s28786043"), ReadingStatus.Finished, 88),
            new UserBook("4", new Book("4", "文学讲稿", "s29767494"), ReadingStatus.Unread, 0),
            new UserBook("5", new Book("5", "洛丽塔", "s32299170"), ReadingStatus.Reading, 6),
            new UserBook("6", new Book("6", "透明社会", "s33503306"), ReadingStatus.Finished, 99),
            new UserBook("7", new Book("7", "一个青年艺术家的画像", "s33673418"), ReadingStatus.Unread, 0),
            new UserBook("8", new Book("8", "没有个性的人", "s33974950"), ReadingStatus.Reading, 111),
            new UserBook("9", new Book("9", "到灯塔去", "s34295465"), ReadingStatus.Finished, 66),
            new UserBook("10", new Book("10", "达洛卫夫人", "s34300732"), ReadingStatus.Reading, 10)
        };
        return UserBooks.GetRange(0, count);
    }

    public ICollection<UserBook> GetUserBooks()
    {
        List<UserBook> UserBooks = new List<UserBook>
        {
            new UserBook("1", new Book("1", "尤利西斯", "s10389470"), ReadingStatus.Unread, 0),
            new UserBook("2", new Book("2", "如何阅读一本书", "s1670978"), ReadingStatus.Reading, 10),
            new UserBook("3", new Book("3", "婚变", "s28786043"), ReadingStatus.Finished, 88),
            new UserBook("4", new Book("4", "文学讲稿", "s29767494"), ReadingStatus.Unread, 0),
            new UserBook("5", new Book("5", "洛丽塔", "s32299170"), ReadingStatus.Reading, 6),
            new UserBook("6", new Book("6", "透明社会", "s33503306"), ReadingStatus.Finished, 99),
            new UserBook("7", new Book("7", "一个青年艺术家的画像", "s33673418"), ReadingStatus.Unread, 0),
            new UserBook("8", new Book("8", "没有个性的人", "s33974950"), ReadingStatus.Reading, 111),
            new UserBook("9", new Book("9", "到灯塔去", "s34295465"), ReadingStatus.Finished, 66),
            new UserBook("10", new Book("10", "达洛卫夫人", "s34300732"), ReadingStatus.Reading, 10)
        };

        return UserBooks;
    }
}
