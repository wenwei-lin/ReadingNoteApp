using Microsoft.EntityFrameworkCore;

namespace ReadingNoteAppService.Models;

public class ReadingNoteContext : DbContext
{
    public ReadingNoteContext(DbContextOptions<ReadingNoteContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Note> Notes { get; set; }

}
