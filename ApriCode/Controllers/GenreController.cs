using ApriCode.Bll.Models;
using ApriCode.Bll.Services.Interfaces;
using ApriCode.Models.Request;
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
            return await _genreService.AddGenre(_mapper.Map<GenreModel>(genre));
        }
    }
}
