using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    /// <summary>
    /// Repository interface for movie data operations.
    /// </summary>
    public interface IMovieRepository
    {
        /// <summary>Retrieves all movies asynchronously.</summary>
        Task<IEnumerable<Movie>> GetAllAsync();

        /// <summary>Retrieves a movie by ID asynchronously.</summary>
        Task<Movie?> GetByIdAsync(int id);

        /// <summary>Adds a new movie asynchronously.</summary>
        Task AddAsync(Movie movie);
    }
}