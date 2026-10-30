using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetAllAsync() => await _context.Movies.ToListAsync();

        public async Task<Movie?> GetByIdAsync(int id) => await _context.Movies.FindAsync(id);

        public async Task AddAsync(Movie movie) => await _context.Movies.AddAsync(movie);

        public async Task UpdateAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var movie = await GetByIdAsync(id);
            if (movie != null) _context.Movies.Remove(movie);
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task<IEnumerable<Movie>> SearchByTitleAsync(string titleKeyword)
        {
            return await _context.Movies
                .Where(m => m.Title.ToLower().Contains(titleKeyword.ToLower()))
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> FilterByGenreAndRatingAsync(string genre, decimal minRating)
        {
            return await _context.Movies
                .Where(m => m.Genre.ToLower() == genre.ToLower() && m.Rating >= minRating)
                .ToListAsync();
        }
    }
}