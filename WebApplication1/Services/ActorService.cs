using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    /// <summary>
    /// Service responsible for managing actor business logic.
    /// </summary>
    public class ActorService
    {
        private readonly IActorRepository _actorRepository;

        /// <summary>
        /// Initializes a new instance of ActorService.
        /// </summary>
        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        /// <summary>Retrieves all actors asynchronously.</summary>
        public async Task<IEnumerable<Actor>> GetActorsAsync()
        {
            return await _actorRepository.GetAllActorsAsync();
        }

        /// <summary>Retrieves an actor by ID asynchronously.</summary>
        public async Task<Actor?> GetActorByIdAsync(int id)
        {
            return await _actorRepository.GetActorByIdAsync(id);
        }

        /// <summary>Creates a new actor asynchronously.</summary>
        public async Task CreateActorAsync(Actor actor)
        {
            await _actorRepository.AddActorAsync(actor);
        }
    }
}