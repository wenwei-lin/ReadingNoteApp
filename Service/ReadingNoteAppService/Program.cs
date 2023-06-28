using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ReadingNoteAppService.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ReadingNote") ?? "Data Source=reading_note.db";

// Config Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Reading Note App API", Description="书是别人的，读书笔记才是自己的", Version = "v1" });
});

// Add DB context
builder.Services.AddSqlite<ReadingNoteContext>(connectionString);

var app = builder.Build();

// Config Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Reading Note App API v1");
});


app.MapGet("/", () => "Welcome to Reading Note App API!");

// Endpoints for book table
app.MapGet("/book", async (ReadingNoteContext db) =>
{
    var allBooks = await db.Books.Include(book => book.Notes).ToListAsync();
    List<BookOutputModel> bookOutputList = new();
    foreach (var book in allBooks)
    {
        BookOutputModel bookOutput = new()
        {
            Id = book.Id,
            Title = book.Title,
            Description = book.Description,
            Cover = book.Cover,
            NoteIds = book.Notes.Select(note => note.Id).ToList()
        };
        bookOutputList.Add(bookOutput);
    }
    return Results.Ok(bookOutputList);
});
app.MapGet("/book/{id}", async (ReadingNoteContext db, int id) =>
{
    var book = await db.Books.Include(book => book.Notes).FirstOrDefaultAsync(book => book.Id == id);
    if (book == null)
    {
        return Results.NotFound();
    }
    
    BookOutputModel bookOutput = new()
    {
        Id = book.Id,
        Title = book.Title,
        Description = book.Description,
        Cover = book.Cover,
        NoteIds = book.Notes.Select(note => note.Id).ToList()
    };

    return Results.Ok(bookOutput);
});
app.MapPost("/book" ,async (ReadingNoteContext db, BookInputModel bookInputModel) =>
{
    var book = new Book
    {
        Title = bookInputModel.Title,
        Description = bookInputModel.Description,
        Cover = bookInputModel.Cover
    };
    await db.Books.AddAsync(book);
    await db.SaveChangesAsync();
    return Results.Created($"/book/{book.Id}", book);
});
app.MapPut("/book/{id}", async (ReadingNoteContext db, int id, BookInputModel updateBook) =>
{
    // 从数据库中读取已有的数据
    var book = await db.Books.FindAsync(id);
    if (book == null)
    {
        return Results.NotFound();
    }

    // 使用传入的数据更新已有的数据
    book.Title = updateBook.Title;
    book.Description = updateBook.Description;
    book.Cover = updateBook.Cover;

    // 更新数据库
    await db.SaveChangesAsync();
    return Results.NoContent();
});
app.MapDelete("/book/{id}", async(ReadingNoteContext db, int id) =>
{
    var book = await db.Books.FindAsync(id);
    if (book == null)
    {
        return Results.NotFound();
    }

    db.Books.Remove(book);
    await db.SaveChangesAsync();
    return Results.NoContent();
});


// Endpoint for tag table
app.MapGet("/tag", async (ReadingNoteContext db) =>
{
    var allTags = await db.Tags.Include(tag => tag.Notes).ToListAsync();
    List<TagOutputModel> tagOutputList = new();
    foreach (var tag in allTags)
    {
        TagOutputModel tagOutput = new()
        {
            Id = tag.Id,
            Title = tag.Title,
            NoteIds = tag.Notes.Select(note => note.Id).ToList()
        };
        tagOutputList.Add(tagOutput);
    }
    return Results.Ok(tagOutputList);
});
app.MapGet("/tag/{id}", async (ReadingNoteContext db, int id) =>
{
    var tag = await db.Tags.Include(tag => tag.Notes).FirstOrDefaultAsync(tag => tag.Id == id);
    if (tag == null)
    {
        return Results.NotFound();
    }

    TagOutputModel tagOutputModel = new()
    {
        Id = tag.Id,
        Title = tag.Title,
        NoteIds = tag.Notes.Select(note => note.Id).ToList()
    };

    return Results.Ok(tagOutputModel);
});
app.MapPost("/tag", async (ReadingNoteContext db, TagInputModel tagInputeModel) =>
{
    var tag = new Tag
    {
        Title = tagInputeModel.Title
    };

    await db.Tags.AddAsync(tag);
    await db.SaveChangesAsync();
    return Results.Created($"/tag/{tag.Id}", tag);
});
app.MapPut("/tag/{id}", async (ReadingNoteContext db, int id, TagInputModel updateTag) =>
{
    var tag = await db.Tags.FindAsync(id);
    if (tag == null)
    {
        return Results.NotFound();
    }

    tag.Title = updateTag.Title;
    await db.SaveChangesAsync();
    return Results.NoContent();
});
app.MapDelete("/tag/{id}", async (ReadingNoteContext db, int id) =>
{
    var tag = await db.Tags.FindAsync(id);
    if (tag == null)
    {
        return Results.NotFound();
    }

    db.Tags.Remove(tag);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

// Endpoints for notes table
app.MapGet("/note", async (ReadingNoteContext db) =>
{
    var allNotes = await db.Notes.Include(note => note.Tags).ToListAsync();
    List<NoteOutputModel> noteOutputList = new();
    foreach (var note in allNotes)
    {
        NoteOutputModel noteOutput = new()
        {
            Id = note.Id,
            Content = note.Content,
            BookId = note.BookId,
            TagIds = note.Tags.Select(tag => tag.Id).ToList()
        };
        noteOutputList.Add(noteOutput);
    }
    
    return Results.Json(noteOutputList);
    
}); 
app.MapGet("/note/{id}", async (ReadingNoteContext db, int id) =>
{
    var note = await db.Notes.Include(note => note.Tags).FirstOrDefaultAsync(note => note.Id == id);
    if (note == null)
    {
        return Results.NotFound();
    }

    NoteOutputModel noteOutput = new()
    {
        Id = note.Id,
        Content = note.Content,
        BookId = note.BookId,
        TagIds = note.Tags.Select(tag => tag.Id).ToList()
    };

    return Results.Ok(noteOutput);
});
app.MapPost("/note", async (ReadingNoteContext db, NoteInputModel noteInputModel) =>
{
    var book = await db.Books.FindAsync(noteInputModel.BookId);
    if (book == null)
    {
        return Results.NotFound();
    }

    var tags = await db.Tags.Where(tag => noteInputModel.TagIds.Contains(tag.Id)).ToListAsync();
    if (tags.Count != noteInputModel.TagIds.Count)
    {
        return Results.NotFound();
    }

    var note = new Note
    {
        Content = noteInputModel.Content,
        BookId = noteInputModel.BookId,
        Tags = tags
    };

    await db.Notes.AddAsync(note);
    await db.SaveChangesAsync();

    var noteOutput = new NoteOutputModel
    {
        Id = note.Id,
        Content = note.Content,
        BookId = note.BookId,
        TagIds = note.Tags.Select(tag => tag.Id).ToList()
    };
    return Results.Created($"/note/{note.Id}", noteOutput);
});
app.MapPut("/note/{id}", async (ReadingNoteContext db, int id, NoteInputModel updateNote) =>
{
    var note = await db.Notes.FindAsync(id);
    if (note == null)
    {
        return Results.NotFound();
    }

    var book = await db.Books.FindAsync(updateNote.BookId);
    if (book == null)
    {
        return Results.NotFound();
    }

    var tags = await db.Tags.Where(tag => updateNote.TagIds.Contains(tag.Id)).ToListAsync();
    if (tags.Count != updateNote.TagIds.Count)
    {
        return Results.NotFound();
    }

    note.Content = updateNote.Content;
    note.BookId = updateNote.BookId;
    note.Tags = tags;

    await db.SaveChangesAsync();
    return Results.NoContent();
}); 
app.MapDelete("/note/{id}", async (ReadingNoteContext db, int id) =>
{
    var note = await db.Notes.FindAsync(id);
    if (note == null)
    {
        return Results.NotFound();
    }

    db.Notes.Remove(note);
    await db.SaveChangesAsync();
    return Results.NoContent();
});


app.Run();
