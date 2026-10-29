using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IDirectorRepository
    {
        Task<IEnumerable<Director>> GetAllDirectorsAsync();
        Task<Director?> GetDirectorByIdAsync(int id);
        Task AddDirectorAsync(Director director);
    }
}