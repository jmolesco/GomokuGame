using PG.API.DataModels;
using AutoMapper;
using PG.API.ResponseModels;
using PG.API.DTO;

namespace PG.API.Infrastructure.AutoMapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BoardResponse, BoardGame>()
              .ReverseMap();
            CreateMap<BoardDesignRequest, BoardDesign>().
             ReverseMap();
            CreateMap<BoardDesignResponseModel, BoardDesign>().
                ReverseMap();
            CreateMap<PlayerRequest, Player>().
     ReverseMap();
            CreateMap<PlayerResponse, Player>().
ReverseMap();
            CreateMap<BoardPlayerResponse, BoardPlayer>().
ReverseMap();
            CreateMap<BoardPlayerRequest, BoardPlayer>().
ReverseMap();


            //CreateMap<ClientListResponse, Client>()
            //    .ReverseMap()
            //    .ForMember(p => p.Name, opt => {
            //        opt.MapFrom(source=>source.FirstName + "   "+ source.LastName) ;
            //    });
            //;

        }
    }
}
