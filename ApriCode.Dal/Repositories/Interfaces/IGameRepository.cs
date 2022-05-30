using ApriCode.Dal.Entities;

namespace ApriCode.Dal.Repositories.Interfaces
{
    public interface IGameRepository
    {
        Task<int> AddGame(Game game);
    }
}
