using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Director
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public string Bio { get; set; } = string.Empty;

        // Navigation property for One-to-Many relationship
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}