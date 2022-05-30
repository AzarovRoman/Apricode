using ApriCode.Bll.Models;
using ApriCode.Bll.Services.Interfaces;
using ApriCode.Dal.Entities;
using ApriCode.Dal.Repositories.Interfaces;
using AutoMapper;

namespace ApriCode.Bll.Services
{
    public class GameService : IGameService
    {
        private IGameRepository _gameRepository;
        private IMapper _mapper;
        public GameService(IMapper mapper, IGameRepository gameRepo)
        {
            _mapper = mapper;
            _gameRepository = gameRepo;
        }

        public async Task<int> AddGame(GameModel model)
        {
            return await _gameRepository.AddGame(_mapper.Map<Game>(model));
        }
    }
}
