using ReadingNote.Models;

namespace ReadingNote.Services;

public interface IBookService
{
    public ICollection<Book> GetBooks(); 
}
