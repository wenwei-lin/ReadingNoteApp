using Microsoft.EntityFrameworkCore;

namespace ReadingNoteAppService.Models;

public class ReadingNoteContext : DbContext
{
    public ReadingNoteContext(DbContextOptions<ReadingNoteContext> options)
        : base(options)
    {
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<UserBook> UserBooks { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<User> Users { get; set; }

}
