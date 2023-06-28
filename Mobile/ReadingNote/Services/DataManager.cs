using ReadingNote.Models;
using System.Text.Json;

namespace ReadingNote.Services;

public class DataManager
{
    readonly string endpoint;
    readonly HttpClient client;
    JsonSerializerOptions serializerOptions;

    public DataManager(HttpClient client)
    {
        this.client = client;
        this.endpoint = "https://localhost:7063/";
        this.serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<ICollection<Book>> GetAllBooksAsync()
    {
        var response = await client.GetAsync(endpoint + "book");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<ICollection<Book>>(content, serializerOptions);
    }

    public async Task<ICollection<Tag>> GetAllTagsAsync()
    {
        var response = await client.GetAsync(endpoint + "tag");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<ICollection<Tag>>(content, serializerOptions);
    }

    public async Task<ICollection<Note>> GetAllNotesAsync()
    {
        var response = await client.GetAsync(endpoint + "note");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<ICollection<Note>>(content, serializerOptions);
    }
}
