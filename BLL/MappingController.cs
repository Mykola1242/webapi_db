using DAL;
using AutoMapper;

namespace BLL
{
    public class MappingController : Profile
    {
        public MappingController()
        {
            CreateMap<MZone, Zone>()
                .ForMember(dest => dest.ID, opt => opt.Ignore());

            CreateMap<MZone, Zone>()
                .ForMember(dest => dest.Character, opt => opt.MapFrom(src => src.Character))
                .ForMember(dest => dest.Attraction, opt => opt.MapFrom(src => src.Attraction))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
        }
    }
}
