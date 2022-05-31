using ApriCode.Dal.Entities;
using ApriCode.Dal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApriCode.Dal.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private Context _context;

        public GenreRepository(Context context)
        {
            _context = context;
        }

        public async Task<int> AddGenre(Genre genre)
        {
            await _context.Genre.AddAsync(genre);
            _context.SaveChanges();
            return genre.Id;
        }

        public async Task<Genre> GetGenreById(int id)
        {
            return await _context.Genre.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task UpdateGenre(Genre genre)
        {
            _context.Genre.Update(genre);
            _context.SaveChanges();
        }
    }
}
