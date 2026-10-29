using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class MovieService
    {
        private readonly IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Movie>> GetMoviesAsync() => _repository.GetAllMoviesAsync();
        public Task<Movie?> GetMovieAsync(int id) => _repository.GetMovieByIdAsync(id);
        public Task CreateMovieAsync(Movie movie) => _repository.AddMovieAsync(movie);
        public Task EditMovieAsync(Movie movie) => _repository.UpdateMovieAsync(movie);
        public Task RemoveMovieAsync(int id) => _repository.DeleteMovieAsync(id);
    }
}