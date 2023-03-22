using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorContacts.Shared.Models
{
    public class Contact
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required]
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
    }
}