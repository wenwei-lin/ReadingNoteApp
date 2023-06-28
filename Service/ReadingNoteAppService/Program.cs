using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ReadingNoteAppService.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Config Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Reading Note App API", Description="书是别人的，读书笔记才是自己的", Version = "v1" });
});

// Add DB context
builder.Services.AddDbContext<ReadingNoteContext>(options => options.UseInMemoryDatabase("items"));

var app = builder.Build();

// Config Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Reading Note App API v1");
});


app.MapGet("/", () => "Welcome to Reading Note App API!");

// User table
app.MapGet("/users", async (ReadingNoteContext db) => await db.Users.ToListAsync());
app.MapGet("/users/{id}", async (ReadingNoteContext db, int id) => await db.Users.FindAsync(id));
app.MapPost("/users", async (ReadingNoteContext db, User user) =>
{
    db.Users.Add(user);
    await db.SaveChangesAsync();
    return Results.Created($"/users/{user.Id}", user);
});
app.MapPut("/users/{id}", async (ReadingNoteContext db, int id, User user) =>
{
    if (id != user.Id)
    {
        return Results.BadRequest();
    }

    db.Entry(user).State = EntityState.Modified;
    await db.SaveChangesAsync();

    return Results.NoContent();
});

// Author table
app.MapGet("/authors", async (ReadingNoteContext db) =>
{
    // write like /author/{id} below

});
app.MapGet("/authors/{id}", async (ReadingNoteContext db, int id) =>
{
    // save the author information in object call author
    var author = await db.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);
    if (author == null)
    {
        return Results.NotFound();
    }
    // return the author information
    var response = new
    {
        author.Id,
        author.ChineseName,
        author.OriginalName,
        author.Description,
        author.Avatar,
        Books = author.Books.Select(b => new
        {
            b.Id,
            b.Title,
            b.Description,
            b.Cover,
            b.Publisher,
            b.PublishDate,
            b.ISBN
        })
    };
    return Results.Ok(response);
});
app.MapPost("/authors", async (ReadingNoteContext db, AuthorInputModel authorInput) =>
{
    Author author = new()
    {
        ChineseName = authorInput.ChineseName,
        OriginalName = authorInput.OriginalName,
        Description = authorInput.Description,
        Avatar = authorInput.Avatar
    };
    db.Authors.Add(author);
    await db.SaveChangesAsync();
    return Results.Created($"/users/{author.Id}", author);
});


// Book table
app.MapGet("/books", async (ReadingNoteContext db) =>
{
    return await db.Books.Include(b => b.Authors).ToListAsync();
});
app.MapGet("/books/{id}", async (ReadingNoteContext db, int id) =>
{
    return await db.Books.Include(b => b.Authors).FirstOrDefaultAsync(b => b.Id == id);
    
});
app.MapPost("/books", async (ReadingNoteContext db, BookInputModel bookInput) =>
{
    var options = new JsonSerializerOptions
    {
        ReferenceHandler = ReferenceHandler.Preserve // 处理对象循环引用
    };

    var book = new Book
    {
        Title = bookInput.Title,
        Description = bookInput.Description,
        Cover = bookInput.Cover,
        Publisher = bookInput.Publisher,
        PublishDate = bookInput.PublishDate,
        ISBN = bookInput.ISBN,
        Authors = new List<Author>()
    };

    foreach (var authorName in bookInput.AuthorNames)
    {
        var existingAuthor = await db.Authors.FirstOrDefaultAsync(a => a.ChineseName == authorName);
        if (existingAuthor == null)
        {
            var newAuthor = new Author { ChineseName = authorName };
            db.Authors.Add(newAuthor);
            book.Authors.Add(newAuthor);
        }
        else
        {
            book.Authors.Add(existingAuthor);
        }
    }

    await db.Books.AddAsync(book);
    await db.SaveChangesAsync();

    var response = new
    {
        book.Id,
        book.Title,
        book.Description,
        book.Cover,
        book.Publisher,
        book.PublishDate,
        book.ISBN,
        Authors = book.Authors.Select(a => new
        {
            a.Id,
            a.ChineseName,
            a.OriginalName,
            a.Description,
            a.Avatar
        })
    };

    return Results.Created($"/books/{book.Id}", response);

});



app.Run();
