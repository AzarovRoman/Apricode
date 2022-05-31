using ApriCode.Bll.Models;

namespace ApriCode.Bll.Services.Interfaces
{
    public interface IGenreService
    {
        Task<int> AddGenre(GenreModel model);
        Task UpdateGenreById(int id, GenreModel model);
        Task<GenreModel> GetGenreById(int id);
        Task DeleteGenreById(int id);
    }
}
