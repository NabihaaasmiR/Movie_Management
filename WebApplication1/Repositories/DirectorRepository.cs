using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly ApplicationDbContext _context;

        public DirectorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Director>> GetAllDirectorsAsync() =>
            await _context.Directors.Include(d => d.Movies).AsNoTracking().ToListAsync();

        public async Task<Director?> GetDirectorByIdAsync(int id) =>
            await _context.Directors.Include(d => d.Movies).FirstOrDefaultAsync(d => d.Id == id);

        public async Task AddDirectorAsync(Director director)
        {
            await _context.Directors.AddAsync(director);
            await _context.SaveChangesAsync();
        }
    }
}