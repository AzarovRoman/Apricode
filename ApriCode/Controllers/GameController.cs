using ApriCode.Bll.Models;
using ApriCode.Bll.Services.Interfaces;
using ApriCode.Models.Request;
using ApriCode.Models.Response;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApriCode.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private IMapper _mapper;
        private IGameService _gameService;

        public GameController(IMapper mapper, IGameService gameService)
        {
            _mapper = mapper;
            _gameService = gameService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddGame(AddGameRequest game)
        {
            int id = await _gameService.AddGame(_mapper.Map<GameModel>(game));
            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameResponse>> GetGameById(int id)
        {
            var game = await _gameService.GetGameById(id);
            return Ok(_mapper.Map<GameResponse>(game));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGameById(int id)
        {
            await _gameService.DeleteGameById(id);
            return Ok();
        }

        [HttpPost("update/{id}")]
        public async Task<ActionResult> UpdateGameById(int id, UpdateGameRequest model)
        {
            await _gameService.UpdateModelById(id, _mapper.Map<GameModel>(model));
            return Ok();
        }

        [HttpPatch("{gameId}/add-genre/{genreId}")]
        public async Task<ActionResult> AddGenreInGameById(int gameId, int genreId)
        {
            await _gameService.AddGenreInGameById(gameId, genreId);
            return Ok();
        }

        [HttpPatch("{gameId}/delete-genre/{genreId}")]
        public async Task<ActionResult> DeleteGenreInGameById(int gameId, int genreId)
        {
            await _gameService.DeleteGenreInGameById(gameId, genreId);
            return Ok();
        }
    }
}
