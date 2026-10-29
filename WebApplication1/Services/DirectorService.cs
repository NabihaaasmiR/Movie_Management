using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class DirectorService
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorService(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public async Task<IEnumerable<Director>> GetDirectorsAsync() =>
            await _directorRepository.GetAllDirectorsAsync();

        public async Task<Director?> GetDirectorAsync(int id) =>
            await _directorRepository.GetDirectorByIdAsync(id);

        public async Task CreateDirectorAsync(Director director) =>
            await _directorRepository.AddDirectorAsync(director);
    }
}