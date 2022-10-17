using AutoMapper;
using DataLib.Entities.Poligraph;
using React3x4.Mapper.MapperModels;
using React3x4.Mapper.MapperModels.PoligraphVM;

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
            
            CreateMap<Flyer, FlyersViewModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(dest => dest.Id))
                .ForMember(dest => dest.Format, source => source.MapFrom(dest => dest.Format))
                .ForMember(dest => dest.Qty, source => source.MapFrom(dest => dest.Qty))
                .ForMember(dest => dest.Price, source => source.MapFrom(dest => dest.Price));

            CreateMap<Calendar, CalendarsViewModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(dest => dest.Id))
                .ForMember(dest => dest.Density, source => source.MapFrom(dest => dest.Density))
                .ForMember(dest => dest.Laminating, source => source.MapFrom(dest => dest.Laminating))
                .ForMember(dest => dest.Price, source => source.MapFrom(dest => dest.Price));


        }

    }
    
}
