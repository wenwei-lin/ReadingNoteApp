using ReadingNote.Models;

namespace ReadingNote.Services;

public class MockNoteService : INoteService
{
    public ICollection<Note> GetNotes()
    {
        throw new NotImplementedException();
    }

    public ICollection<Note> GetRecentNotes(int count)
    {
        throw new NotImplementedException();
    }
}
