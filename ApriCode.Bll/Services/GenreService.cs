using ApriCode.Bll.Exceptions;
using ApriCode.Bll.Models;
using ApriCode.Bll.Services.Interfaces;
using ApriCode.Dal.Entities;
using ApriCode.Dal.Repositories.Interfaces;
using AutoMapper;

namespace ApriCode.Bll.Services
{
    public class GenreService : IGenreService
    {
        private IMapper _mapper;
        private IGenreRepository _genreRepository;

        public GenreService(IMapper mapper, IGenreRepository genreRepo)
        {
            _mapper = mapper;
            _genreRepository = genreRepo;
        }

        public async Task<int> AddGenre(GenreModel model)
        {
            return await _genreRepository.AddGenre(_mapper.Map<Genre>(model));
        }

        public async Task UpdateGenreById(int id, GenreModel model)
        {
            var genre = await _genreRepository.GetGenreById(id);

            if (genre is null)
            {
                throw new NotFoundException($"Нет жанра с id = {id}");
            }

            genre.Name = model.Name;

            await _genreRepository.UpdateGenre(genre);
        }

        public async Task<GenreModel> GetGenreById(int id)
        {
            var genre = await _genreRepository.GetGenreById(id);

            if (genre is null)
            {
                throw new NotFoundException($"Нет жанра с id = {id}");
            }

            return _mapper.Map<GenreModel>(genre);
        }

        public async Task DeleteGenreById(int id)
        {
            var genre = await _genreRepository.GetGenreById(id);

            if (genre is null)
            {
                throw new NotFoundException($"Нет жанра с id = {id}");
            }

            await _genreRepository.DeleteGenre(genre);
        }
    }
}
