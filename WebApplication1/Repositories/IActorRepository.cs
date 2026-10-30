using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    /// <summary>
    /// Repository interface for actor data operations.
    /// </summary>
    public interface IActorRepository
    {
        /// <summary>Retrieves all actors asynchronously.</summary>
        Task<IEnumerable<Actor>> GetAllActorsAsync();

        /// <summary>Retrieves an actor by ID asynchronously.</summary>
        Task<Actor?> GetActorByIdAsync(int id);

        /// <summary>Adds a new actor asynchronously.</summary>
        Task AddActorAsync(Actor actor);
    }
}