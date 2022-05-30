using ApriCode.Dal.Entities;
using ApriCode.Dal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Game> GetGameById(int id)
        {
            return await _context.Game.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task DeleteGame(Game game)
        {
            _context.Game.Remove(game);
            _context.SaveChanges();
        }

        public async Task UpdateGame(Game game)
        {
            _context.Update(game);
            _context.SaveChanges();
        }
    }
}
