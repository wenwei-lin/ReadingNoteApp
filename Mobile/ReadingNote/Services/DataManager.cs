using ReadingNote.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace ReadingNote.Services;

public class DataManager
{
    readonly string endpoint;
    readonly HttpClient client;
    JsonSerializerOptions serializerOptions;

    public DataManager()
    {
        client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        this.endpoint = "http://10.0.2.2:5125/";
        this.serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<ICollection<Book>> GetAllBooksAsync()
    {
        var response = await client.GetAsync(endpoint + "book");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var books = JsonSerializer.Deserialize<ICollection<Book>>(content, serializerOptions);
        // add notes
        foreach (var book in books)
        {
            if (book.NoteIds != null)
            {
                ICollection<Note> notes = new List<Note>();
                foreach (var noteId in book.NoteIds)
                {
                    var note = await GetNoteAsync(noteId);
                    notes.Add(note);
                }
                book.Notes = notes;
            }
        }
        return books;
    }

    public async Task<Book> GetBookAsync(int id, bool loadNote)
    {
        var response = await client.GetAsync(endpoint + "book/" + id);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var book = JsonSerializer.Deserialize<Book>(content, serializerOptions);

        // get notes
        if (book.NoteIds != null && loadNote)
        {
            ICollection<Note> notes = new List<Note>();
            foreach (var noteId in book.NoteIds)
            {
                var note = await GetNoteAsync(noteId);
                notes.Add(note);
            }
            book.Notes = notes;
        }

        return book;
    }

    public async Task<ICollection<Tag>> GetAllTagsAsync()
    {
        var response = await client.GetAsync(endpoint + "tag");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<ICollection<Tag>>(content, serializerOptions);
    }

    public async Task<Tag> GetTagAsync(int id)
    {
        var response = await client.GetAsync(endpoint + "tag/" + id);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Tag>(content, serializerOptions);
    }

    // 添加Tag
    public async Task<Tag> AddTagAsync(Tag tag)
    {
        var response = await client.PostAsJsonAsync(endpoint + "tag", tag);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Tag>(content, serializerOptions);
    }

    public async Task<ICollection<Note>> GetAllNotesAsync()
    {
        var response = await client.GetAsync(endpoint + "note");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        ICollection<Note> notes = JsonSerializer.Deserialize<ICollection<Note>>(content, serializerOptions);

        foreach (var note in notes)
        {
            if (note.BookId != null)
            {
                note.Book = await GetBookAsync(note.BookId, false);
            }
            if (note.TagIds != null)
            {
                ICollection<Tag> tags = new List<Tag>();
                foreach (var tagId in note.TagIds)
                {
                    var tag = await GetTagAsync(tagId);
                    tags.Add(tag);
                }
                note.Tags = tags;
            }
        }

        return notes;
    }

    public async Task<Note> GetNoteAsync(int id)
    {
        var response = await client.GetAsync(endpoint + "note/" + id);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var note = JsonSerializer.Deserialize<Note>(content, serializerOptions);

        if (note.BookId != null)
        {
            note.Book = await GetBookAsync(note.BookId, false);
        }
        if (note.TagIds != null)
        {
            ICollection<Tag> tags = new List<Tag>();
            foreach (var tagId in note.TagIds)
            {
                var tag = await GetTagAsync(tagId);
                tags.Add(tag);
            }
            note.Tags = tags;
        }

        return note;
    }

    public async Task<Note> AddNoteAsync(Note note)
    {
        int bookId = 0;
        if (note.Book != null)
        {
            bookId = note.Book.Id;
        }

        ICollection<int> tagIds = new List<int>();
        if (note.Tags != null)
        {
            foreach (var tag in note.Tags)
            {
                tagIds.Add(tag.Id.Value);
            }
        }

        // Create request body as {"content", "bookId", "tagIds"}
        var requestBody = new Dictionary<string, object>
        {
            { "content", note.Content },
            { "bookId", bookId },
            { "tagIds", tagIds }
        };

        var response = await client.PostAsJsonAsync(endpoint + "note", requestBody);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Note>(content, serializerOptions);
    }

    public async Task DeleteNoteAsync(Note note)
    {
        await client.DeleteAsync(endpoint + "note/" + note.Id);
    }
}


