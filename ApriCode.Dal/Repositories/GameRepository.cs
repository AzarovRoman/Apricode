using ApriCode.Dal.Entities;
using ApriCode.Dal.Repositories.Interfaces;

namespace ApriCode.Dal.Repositories
{
    public class GameRepository : IGameRepository
    {
        private Context _context;
        public GameRepository(Context context)
        {
            _context = context;
        }

        public async Task<int> AddGame(Game game)
        {
            await _context.Game.AddAsync(game);
            await _context.SaveChangesAsync();
            return game.Id;
        }
    }
}
