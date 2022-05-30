using ApriCode.Dal.Entities;

namespace ApriCode.Dal.Repositories.Interfaces
{
    public interface IGameRepository
    {
        Task<int> AddGame(Game game);
        Task<Game> GetGameById(int id);
        Task DeleteGame(Game game);
        Task UpdateGame(Game game);
        Task AddGenreInGame(Game game, Genre genre);
        Task DeleteGenreInGame(Game game, Genre genre);
    }
}
