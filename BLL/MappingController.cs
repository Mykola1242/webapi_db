using DAL;
using AutoMapper;

namespace BLL
{
    public class MappingController : Profile
    {
        public MappingController()
        {
            CreateMap<Billboard, DBBillboard>()
                .ForMember(dest => dest.ID, opt => opt.Ignore());

            CreateMap<Billboard, DBBillboard>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
        }
    }
}
