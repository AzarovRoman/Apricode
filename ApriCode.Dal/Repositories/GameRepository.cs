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
            _context.Game.Update(game);
            _context.SaveChanges();
        }

        public async Task AddGenreInGame(Game game, Genre genre)
        {
            game.Genres.Add(genre);
            _context.SaveChanges();
        }

        public async Task DeleteGenreInGame(Game game, Genre genre)
        {
            game.Genres.Remove(genre);
            _context.SaveChanges();
        }

        public async Task<List<Game>> GetGamesByGenre(Genre genre)
        {
            List<Game> games = await _context.Game
                .Where(g => g.Genres.Contains(genre))
                .ToListAsync();

            return games;
        }
    }
}
