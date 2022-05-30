using ApriCode.Bll.Models;
using ApriCode.Models.Request;
using ApriCode.Models.Response;
using AutoMapper;

namespace ApriCode.Config
{
    public class ApiMapper : Profile
    {
        public ApiMapper()
        {
            CreateMap<GameModel, GameResponse>();
            CreateMap<AddGameRequest, GameModel>();

            CreateMap<GenreModel, GenreResponse>();
        }
    }
}
