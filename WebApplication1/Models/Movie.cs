using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Genre { get; set; } = string.Empty;

        public int ReleaseYear { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Range(0.0, 10.0)]
        public decimal Rating { get; set; }
    }
}