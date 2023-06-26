namespace ReadingNote.Models;

public class Book
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string AuthorId { get; set; }
    public Author Author { get; set; }
    public string TranslatorId { get; set; }
    public Author Translator { get; set; }
    public string Publisher { get; set; }
    public string ISBN { get; set; }
    public string Cover { get; set; }
    public string Description { get; set; }
}