using ReadingNote.Models;

namespace ReadingNote.Services;

public interface IBooklistService
{
    public ICollection<Booklist> GetBooklists();
}
