using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class MovieService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMovieRepository _movieRepository;
        private readonly AuditService _auditService;

        public MovieService(
            ApplicationDbContext context,
            IMovieRepository movieRepository,
            AuditService auditService)
        {
            _context = context;
            _movieRepository = movieRepository;
            _auditService = auditService;
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _movieRepository.GetAllAsync();
        }

        public async Task<Movie?> GetMovieByIdAsync(int id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }

        public async Task CreateMovieAsync(Movie movie)
        {
            // Validate release date (1888 - present + 5 years)
            var earliestValidDate = new DateTime(1888, 1, 1);
            if (movie.ReleaseDate < earliestValidDate || movie.ReleaseDate > DateTime.UtcNow.AddYears(5))
            {
                throw new ArgumentException("Invalid release date. Must be between 1888 and 5 years into the future.");
            }

            // Begin atomic transaction
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Add movie via repository
                await _movieRepository.AddAsync(movie);

                // Log the action to audit logs
                await _auditService.LogActionAsync("CREATE_MOVIE", $"Movie '{movie.Title}' was created successfully.");

                // Commit transaction
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}