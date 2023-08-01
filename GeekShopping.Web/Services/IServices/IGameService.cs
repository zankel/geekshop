using GGstore.Web.Models;


namespace GGstore.Web.Services.IServices
{
    public interface IGameService
    {
        Task<IEnumerable<GameModel>> FindAllGames();
        Task<GameModel> FindGameById(long id);
        Task<GameModel> CreateGame(GameModel model);
        Task<GameModel> UpdateGame(GameModel model);
        Task<bool> DeleteGameById(long id);
    }
}
