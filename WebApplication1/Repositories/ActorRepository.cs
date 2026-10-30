using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    /// <summary>
    /// Repository implementation for actor data operations.
    /// </summary>
    public class ActorRepository : IActorRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of ActorRepository.
        /// </summary>
        public ActorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Actor>> GetAllActorsAsync()
        {
            return await _context.Actors.ToListAsync();
        }

        /// <inheritdoc />
        public async Task<Actor?> GetActorByIdAsync(int id)
        {
            return await _context.Actors.FindAsync(id);
        }

        /// <inheritdoc />
        public async Task AddActorAsync(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
        }
    }
}