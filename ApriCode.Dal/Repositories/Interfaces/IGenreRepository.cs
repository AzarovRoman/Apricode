using ApriCode.Dal.Entities;

namespace ApriCode.Dal.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        Task<int> AddGenre(Genre genre);
        Task<Genre> GetGenreById(int id);
        Task UpdateGenre(Genre genre);
        Task DeleteGenre(Genre genre);
    }
}
