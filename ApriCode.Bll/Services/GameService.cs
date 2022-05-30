using ApriCode.Bll.Exceptions;
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

        public async Task<GameModel> GetGameById(int id)
        {
            var game =  await _gameRepository.GetGameById(id);

            if (game is null)
            {
                throw new NotFoundException($"Нет игры с id = {id}");
            }

            return _mapper.Map<GameModel>(game);
        }

        public async Task DeleteGameById(int id)
        {
            var game = await _gameRepository.GetGameById(id);

            if (game is null)
            {
                throw new NotFoundException($"Нет игры с id = {id}");
            }

            await _gameRepository.DeleteGame(game);
        }

        public async Task UpdateModelById(int id, GameModel model)
        {
            var game = await _gameRepository.GetGameById(id);

            if (game is null)
            {
                throw new NotFoundException($"Нет игры с id = {id}");
            }

            game.Name = model.Name;
            game.Publisher = model.Publisher;

            await _gameRepository.UpdateGame(game);
        }
    }
}
