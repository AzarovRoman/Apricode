using ApriCode.Dal.Entities;
using ApriCode.Dal.Repositories.Interfaces;

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
    }
}
