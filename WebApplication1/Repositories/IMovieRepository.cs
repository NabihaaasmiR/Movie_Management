using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(int id);
        Task AddAsync(Movie movie);
        Task UpdateAsync(Movie movie);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();

        // LINQ Search & Filter methods
        Task<IEnumerable<Movie>> SearchByTitleAsync(string titleKeyword);
        Task<IEnumerable<Movie>> FilterByGenreAndRatingAsync(string genre, decimal minRating);
    }
}