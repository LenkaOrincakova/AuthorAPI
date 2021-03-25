using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AuthorAPI.Models
{
    public class Book
    {
        [JsonPropertyName("isbn"), Key]
        public int ISBN { get; set; }
        [Required, MaxLength(40)]
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("publicationYear")]
        public int PublicationYear { get; set; }
        [JsonPropertyName("numOfPages")]
        public int NumOfPages { get; set; }
        [JsonPropertyName("genre")]
        public string Genre { get; set; }
        [JsonPropertyName("author")]
        public Author Author { get; set; }
        
    }
}
