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

            CreateMap<Birka, BirkasViewModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(dest => dest.Id))
                .ForMember(dest => dest.Format, source => source.MapFrom(dest => dest.Format))
                .ForMember(dest => dest.Density, source => source.MapFrom(dest => dest.Density))
                .ForMember(dest => dest.Price, source => source.MapFrom(dest => dest.Price));

            CreateMap<Sticker, StickersViewModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(dest => dest.Id))
                .ForMember(dest => dest.Format, source => source.MapFrom(dest => dest.Format))
                .ForMember(dest => dest.Qty, source => source.MapFrom(dest => dest.Qty))
                .ForMember(dest => dest.Price, source => source.MapFrom(dest => dest.Price));

            CreateMap<Hanger, HangersViewModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(dest => dest.Id))
                .ForMember(dest => dest.Qty, source => source.MapFrom(dest => dest.Qty))
                .ForMember(dest => dest.Price, source => source.MapFrom(dest => dest.Price));

            CreateMap<Oracal, OracalsViewModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(dest => dest.Id))
                .ForMember(dest => dest.Tape, source => source.MapFrom(dest => dest.Tape))
                .ForMember(dest => dest.Laminating, source => source.MapFrom(dest => dest.Laminating))
                .ForMember(dest => dest.Price, source => source.MapFrom(dest => dest.Price));

            CreateMap<Baner, BanersViewModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(dest => dest.Id))
                .ForMember(dest => dest.Dpi, source => source.MapFrom(dest => dest.Dpi))
                .ForMember(dest => dest.Service, source => source.MapFrom(dest => dest.Service))
                .ForMember(dest => dest.Price, source => source.MapFrom(dest => dest.Price));

            CreateMap<Pvc, PvcsViewModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(dest => dest.Id))
                .ForMember(dest => dest.Thickness, source => source.MapFrom(dest => dest.Thickness))
                .ForMember(dest => dest.Price, source => source.MapFrom(dest => dest.Price));


        }

    }
    
}
