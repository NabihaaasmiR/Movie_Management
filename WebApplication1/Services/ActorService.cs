using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class ActorService
    {
        private readonly IActorRepository _actorRepository;

        public ActorService(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public async Task<IEnumerable<Actor>> GetActorsAsync() =>
            await _actorRepository.GetAllActorsAsync();

        public async Task<Actor?> GetActorAsync(int id) =>
            await _actorRepository.GetActorByIdAsync(id);

        public async Task CreateActorAsync(Actor actor) =>
            await _actorRepository.AddActorAsync(actor);
    }
}