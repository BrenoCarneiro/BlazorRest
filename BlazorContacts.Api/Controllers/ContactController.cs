using Microsoft.AspNetCore.Mvc;
using BlazorContacts.Shared.Models;

namespace BlazorContacts.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private static readonly List<Contact> contacts = CreateContacts(10);

    private static List<Contact> CreateContacts(int number)
    {
        return Enumerable.Range(1, number).Select(index => new Contact
        {
            Id = index,
            Name = $"Name{index} Lastname{index}",
            Email = $"email{index}@example.com",
            Phone = $"+55 123 456{index}"
        }).ToList();
    }

    [HttpGet]
    public ActionResult<List<Contact>> GetResult()
    {
        return contacts;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Contact> GetContactsById(int id)
    {
        var contato = contacts.FirstOrDefault((p) => p.Id == id);
        if (contato == null)
            return NotFound();
        return contato;
    }

    [HttpPost]
    public void AddContact([FromBody] Contact contact)
    {
        contacts.Add(contact);
    }

    [HttpPut("{id}")]
    public void UpdateContact(int id, [FromBody] Contact contact)
    {
        int index = contacts.FindIndex((p) => p.Id == id);
        if (index != -1)
            contacts[index] = contact;
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        int index = contacts.FindIndex((p) => p.Id == id);
        if (index != -1)
            contacts.RemoveAt(index);
    }
}