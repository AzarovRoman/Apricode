using ApriCode.Bll.Models;
using ApriCode.Dal.Entities;
using AutoMapper;

namespace ApriCode.Bll.Config
{
    public class BllMapper : Profile
    {
        public BllMapper()
        {
            CreateMap<Game, GameModel>().ReverseMap();
            CreateMap<Genre, GenreModel>().ReverseMap();
        }
    }
}
