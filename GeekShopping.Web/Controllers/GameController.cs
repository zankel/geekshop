using GeekShopping.Web.Utils;
using GGstore.Web.Models;
using GGstore.Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace GGshop.Web.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService ?? throw new ArgumentNullException(nameof(gameService));
        }

        [Authorize]
        public async Task<IActionResult> GameIndex()
        {
            var products = await _gameService.FindAllGames();
            return View(products);
        }

        public async Task<IActionResult> GameCreate()
        {
            return View();
        }
    
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GameCreate(GameModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _gameService.CreateGame(model);
                if (response != null) return RedirectToAction(
                     nameof(GameIndex));
            }
            return View(model);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> GameUpdate(int id)
        {
            var model = await _gameService.FindGameById(id);
            if (model != null) return View(model);
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> GameUpdate(GameModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _gameService.UpdateGame(model);
                if (response != null) return RedirectToAction(
                     nameof(GameIndex));
            }
            return View(model);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> GameDelete(int id)
        {
            var model = await _gameService.FindGameById(id);
            if (model != null) return View(model);
            return NotFound();
        }
      
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> ProductDelete(GameModel model)
        {
            var response = await _gameService.DeleteGameById(model.Id);
            if (response) return RedirectToAction(
                    nameof(GameIndex));
            return View(model);
        }
    }
}