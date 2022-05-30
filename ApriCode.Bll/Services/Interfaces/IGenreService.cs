using ApriCode.Bll.Models;

namespace ApriCode.Bll.Services.Interfaces
{
    public interface IGenreService
    {
        Task<int> AddGenre(GenreModel model);
    }
}
