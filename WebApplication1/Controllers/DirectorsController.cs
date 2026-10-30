using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly DirectorService _directorService;

        public DirectorsController(DirectorService directorService)
        {
            _directorService = directorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Director>>> GetDirectors()
        {
            var directors = await _directorService.GetDirectorsAsync();
            return Ok(directors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Director>> GetDirector(int id)
        {
            var director = await _directorService.GetDirectorByIdAsync(id);
            if (director == null)
            {
                return NotFound();
            }
            return Ok(director);
        }

        [HttpPost]
        public async Task<ActionResult<Director>> CreateDirector([FromBody] Director director)
        {
            await _directorService.CreateDirectorAsync(director);
            return CreatedAtAction(nameof(GetDirector), new { id = director.Id }, director);
        }
    }
}