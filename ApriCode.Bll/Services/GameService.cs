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
        private IGenreRepository _genreRepository;
        private IMapper _mapper;
        public GameService(IMapper mapper, IGameRepository gameRepo, IGenreRepository genreRepository)
        {
            _mapper = mapper;
            _gameRepository = gameRepo;
            _genreRepository = genreRepository;
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

        public async Task AddGenreInGameById(int gameId, int genreId)
        {
            var game = await _gameRepository.GetGameById(gameId);

            var genre = await _genreRepository.GetGenreById(genreId);

            if (genre is null)
            {
                throw new NotFoundException($"Нет жанра с id = {genreId}");
            }

            if (game is null)
            {
                throw new NotFoundException($"Нет игры с id = {gameId}");
            }

            _gameRepository.AddGenreInGame(game, genre);
        }

        public async Task DeleteGenreInGameById(int gameId, int genreId)
        {
            var game = await _gameRepository.GetGameById(gameId);

            var genre = await _genreRepository.GetGenreById(genreId);

            if (genre is null)
            {
                throw new NotFoundException($"Нет жанра с id = {genreId}");
            }

            if (game is null)
            {
                throw new NotFoundException($"Нет игры с id = {gameId}");
            }

            _gameRepository.DeleteGenreInGame(game, genre);
        }
    }
}
