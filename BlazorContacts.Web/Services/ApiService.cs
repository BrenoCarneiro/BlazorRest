using BlazorContacts.Shared.Models;
using System.Net.Http;
using System.Text.Json;

namespace BlazorContacts.Web.Services;

public class ApiService
{
    private readonly HttpClient httpClient;

    public ApiService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<List<Contact>> GetContactsAsync()
    {
        var response = await httpClient.GetAsync("api/contact");
        response.EnsureSuccessStatusCode();

        using var responseContent = await response.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<List<Contact>>(responseContent);

    }

    public async Task<Contact> GetContactsByIdAsync(int id)
    {
        var response = await httpClient.GetAsync($"api/contact/{id}");
        response.EnsureSuccessStatusCode();
        using var responseContent = await response.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<Contact>(responseContent);
    }
}
