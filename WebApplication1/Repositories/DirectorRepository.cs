using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    /// <summary>
    /// Repository implementation for director data operations.
    /// </summary>
    public class DirectorRepository : IDirectorRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of DirectorRepository.
        /// </summary>
        public DirectorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Director>> GetAllAsync()
        {
            return await _context.Directors.ToListAsync();
        }

        /// <inheritdoc />
        public async Task<Director?> GetByIdAsync(int id)
        {
            return await _context.Directors.FindAsync(id);
        }

        /// <inheritdoc />
        public async Task AddAsync(Director director)
        {
            await _context.Directors.AddAsync(director);
            await _context.SaveChangesAsync();
        }
    }
}