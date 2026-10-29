using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IActorRepository
    {
        Task<IEnumerable<Actor>> GetAllActorsAsync();
        Task<Actor?> GetActorByIdAsync(int id);
        Task AddActorAsync(Actor actor);
    }
}