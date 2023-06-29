﻿namespace ReadingNote.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Cover { get; set; }
    public string Description { get; set; }
    public ICollection<int> NoteIds { get; set; }
    public ICollection<Note> Notes { get; set; }
}
+