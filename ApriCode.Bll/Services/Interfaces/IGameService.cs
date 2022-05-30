using ApriCode.Bll.Models;

namespace ApriCode.Bll.Services.Interfaces
{
    public interface IGameService
    {
        Task<int> AddGame(GameModel model);
        Task<GameModel> GetGameById(int id);
        Task DeleteGameById(int id);
    }
}
