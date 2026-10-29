using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Genre { get; set; } = string.Empty;

        [Range(0.01, 10000.00)]
        public decimal Price { get; set; }

        public DateTime ReleaseDate { get; set; }

        // Foreign Key
        public int DirectorId { get; set; }

        // Navigation property
        public Director? Director { get; set; }
    }
}