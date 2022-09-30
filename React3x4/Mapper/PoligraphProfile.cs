using AutoMapper;
using DataLib.Entities.Poligraph;
using React3x4.Mapper.MapperModels;

namespace React3x4.Mapper
{
    public class PoligraphProfile : Profile
    {
        public PoligraphProfile()
        {
            CreateMap<Visitcard, VisitcardsViewModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(dest => dest.Id))
                .ForMember(dest => dest.Density, source => source.MapFrom(dest => dest.Density))
                .ForMember(dest => dest.Laminating, source => source.MapFrom(dest => dest.Laminating))
                .ForMember(dest => dest.Price, source => source.MapFrom(dest => dest.Price));
        
        }

    }
    
}
