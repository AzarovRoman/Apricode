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
    }
}
