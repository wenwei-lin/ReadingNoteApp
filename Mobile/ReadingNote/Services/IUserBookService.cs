using ReadingNote.Models;

namespace ReadingNote.Services;

public interface IUserBookService
{
    public ICollection<UserBook> GetUserBooks();
    public ICollection<UserBook> GetRecentUserBooks(int count);
}
