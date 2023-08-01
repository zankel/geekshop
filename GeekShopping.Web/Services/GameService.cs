using GeekShopping.Web.Utils;
using GGstore.Web.Models;
using GGstore.Web.Services.IServices;

namespace GGstore.Web.Services
{
    public class GameService : IGameService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/game";

        public GameService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<GameModel>> FindAllGames()
        {        
                var response = await _client.GetAsync(BasePath);
                return await response.ReadContentAs<List<GameModel>>(); 
        }

        public async Task<GameModel> FindGameById(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<GameModel>();
        }

        public async Task<GameModel> CreateGame(GameModel model)
        {
            var response = await _client.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<GameModel>();
            else throw new Exception("Something went wrong when calling API");
        }
        public async Task<GameModel> UpdateGame(GameModel model)
        {
            var response = await _client.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<GameModel>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<bool> DeleteGameById(long id)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else throw new Exception("Something went wrong when calling API");
        }
    }
}
