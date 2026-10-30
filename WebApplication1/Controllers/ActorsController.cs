using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly ActorService _actorService;

        public ActorsController(ActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> GetActors()
        {
            var actors = await _actorService.GetActorsAsync();
            return Ok(actors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Actor>> GetActor(int id)
        {
            var actor = await _actorService.GetActorByIdAsync(id);
            if (actor == null)
            {
                return NotFound(new { message = $"Actor with ID {id} not found." });
            }
            return Ok(actor);
        }

        [HttpPost]
        public async Task<ActionResult<Actor>> CreateActor([FromBody] Actor actor)
        {
            await _actorService.CreateActorAsync(actor);
            return CreatedAtAction(nameof(GetActor), new { id = actor.Id }, actor);
        }
    }
}