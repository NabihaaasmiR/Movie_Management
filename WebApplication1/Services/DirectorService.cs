using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class DirectorService
    {
        private readonly ApplicationDbContext _context;

        public DirectorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Director>> GetDirectorsAsync()
        {
            return await _context.Directors.ToListAsync();
        }

        public async Task<Director?> GetDirectorByIdAsync(int id)
        {
            return await _context.Directors.FindAsync(id);
        }

        public async Task CreateDirectorAsync(Director director)
        {
            _context.Directors.Add(director);
            await _context.SaveChangesAsync();
        }
    }
}