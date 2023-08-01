using GGstore.ProductAPI.Data.ValueObjects;
using GGstore.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GGstore.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private IGameRepository _repository;

        public GameController(IGameRepository repository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameVO>>> FindAll()
        {
            var games = await _repository.FindAll();
            return Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameVO>> FindById(long id)
        {
            var game = await _repository.FindById(id);
            if (game.Id <= 0) return NotFound();
            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<GameVO>> Create([FromBody] GameVO vo)
        {
            if (vo == null) return BadRequest();
            var game = await _repository.Create(vo);
            return Ok(game);
        }

        [HttpPut]
        public async Task<ActionResult<GameVO>> Update([FromBody] GameVO vo)
        {
            if (vo == null) return BadRequest();
            var game = await _repository.Update(vo);
            return Ok(game);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
