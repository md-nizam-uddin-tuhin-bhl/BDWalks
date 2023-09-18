using AutoMapper;
using BDWalksAPI.DTO;
using BDWalksAPI.Models.Domain;

namespace BDWalksAPI.Automapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegionDto,Region>().ForMember(x=>x.Name,opt=>opt.MapFrom(x=>x.FullName)).ReverseMap();
            CreateMap<AddRegionRequestDto,Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();
            CreateMap<WalkDto, Walk>().ReverseMap();
            CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
            CreateMap<UpdateWalksRequestDto, Walk>().ReverseMap();
            CreateMap<DifficultyDto, Difficulty>().ReverseMap();
         
        }
    }
}
