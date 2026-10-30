using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    /// <summary>
    /// Repository interface for director data operations.
    /// </summary>
    public interface IDirectorRepository
    {
        /// <summary>Retrieves all directors asynchronously.</summary>
        Task<IEnumerable<Director>> GetAllAsync();

        /// <summary>Retrieves a director by ID asynchronously.</summary>
        Task<Director?> GetByIdAsync(int id);

        /// <summary>Adds a new director asynchronously.</summary>
        Task AddAsync(Director director);
    }
}