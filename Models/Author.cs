using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AuthorAPI.Models
{
    public class Author
    {
        [JsonPropertyName("id"), Key]
        public int Id { get; set; }
        [Required, MaxLength(15)]
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [Required, MaxLength(15)]
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("books")]
        public List<Book> Books { get; set; }
        public Author()
        {
            Books = new List<Book>();
        }

    }
}
