using ReadingNote.Models;

namespace ReadingNote.Services;

public interface INoteService
{
    public ICollection<Note> GetNotes(); 
    public ICollection<Note> GetRecentNotes(int count);
}

