using ReadingNote.Models;

namespace ReadingNote.Services;

public class MockBookService : IBookService
{
    public ICollection<Book> GetBooks()
    {
        throw new NotImplementedException();
    }
}