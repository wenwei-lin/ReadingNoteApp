﻿namespace ReadingNote.Models;

public class Note
{
    public string Id { get; set; }
    public string Content { get; set; }
    public string PageLocation { get; set; }
    public IEnumerable<Tag> Tags { get; set; }
    public string UserId { get; set; }
    public string BookId { get; set; }
    public Book Book { get; set; }
    public DateTime CreateTime { get; set; }
    public DateTime LastEditTime { get; set;}
}
