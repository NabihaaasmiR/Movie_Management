using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MoviesController(MovieService movieService)
        {
            _movieService = movieService;
        }

        /// <summary>
        /// Retrieves all movies.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            var movies = await _movieService.GetMoviesAsync();
            return Ok(movies);
        }

        /// <summary>
        /// Retrieves a specific movie by its ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        /// <summary>
        /// Creates a new movie with transaction and audit logging.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Movie>> CreateMovie([FromBody] Movie movie)
        {
            try
            {
                await _movieService.CreateMovieAsync(movie);
                return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}