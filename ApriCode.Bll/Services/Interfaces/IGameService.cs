using ApriCode.Bll.Models;

namespace ApriCode.Bll.Services.Interfaces
{
    public interface IGameService
    {
        Task<int> AddGame(GameModel model);
        Task<GameModel> GetGameById(int id);
        Task DeleteGameById(int id);
        Task UpdateModelById(int id, GameModel model);
        Task AddGenreInGameById(int gameId, int genreId);
        Task DeleteGenreInGameById(int gameId, int genreId);
        Task<List<GameModel>> GetGamesByGenreId(int genreId);
    }
}
