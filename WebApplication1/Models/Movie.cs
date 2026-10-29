using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Genre { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}