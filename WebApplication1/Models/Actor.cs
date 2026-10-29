using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Actor
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        // Navigation property for Many-to-Many relationship
        public ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
    }
}