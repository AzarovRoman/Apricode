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
    public class GenreController : Controller
    {
        private IMapper _mapper;
        private IGenreService _genreService;

        public GenreController(IMapper mapper, IGenreService genreService)
        {
            _mapper = mapper;
            _genreService = genreService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddGenre(AddGenreRequest genre)
        {
            var id = await _genreService.AddGenre(_mapper.Map<GenreModel>(genre));
            return Ok(id);
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateGenreById(int id, UpdateGenreRequest model)
        {
            await _genreService.UpdateGenreById(id, _mapper.Map<GenreModel>(model));
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenreResponse>> GetGenreById(int id)
        {
            var genre = await _genreService.GetGenreById(id);
            return Ok(genre);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGenreById(int id)
        {
            await _genreService.DeleteGenreById(id);
            return Ok();
        }
    }
}
