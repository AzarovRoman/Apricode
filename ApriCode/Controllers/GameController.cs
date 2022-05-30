using ApriCode.Bll.Models;
using ApriCode.Bll.Services.Interfaces;
using ApriCode.Models.Request;
using ApriCode.Models.Response;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApriCode.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController
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
            return id;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameResponse>> GetGameById(int id)
        {
            var game = await _gameService.GetGameById(id);
            return _mapper.Map<GameResponse>(game);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGameById(int id)
        {
            await _gameService.DeleteGameById(id);
            return new OkResult();
        }
    }
}
