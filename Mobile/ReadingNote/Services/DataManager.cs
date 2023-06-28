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
        return books;
    }

    public async Task<Book> GetBookAsync(int id)
    {
        var response = await client.GetAsync(endpoint + "book/" + id);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var book = JsonSerializer.Deserialize<Book>(content, serializerOptions);
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
                note.Book = await GetBookAsync(note.BookId);
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

}
