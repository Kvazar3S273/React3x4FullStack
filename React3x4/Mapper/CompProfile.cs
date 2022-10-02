using AutoMapper;
using DataLib.Entities.Comp;
using React3x4.Mapper.MapperModels.CompVM;

namespace React3x4.Mapper
{
    public class CompProfile : Profile
    {
        public CompProfile()
        {
            CreateMap<Xerox, XeroxViewModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(dest => dest.Id))
                .ForMember(dest => dest.Price, source => source.MapFrom(dest => dest.Price));

            CreateMap<BlackPrint, BlackPrintViewModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(dest => dest.Id))
                .ForMember(dest => dest.PriceText, source => source.MapFrom(dest => dest.PriceText))
                .ForMember(dest => dest.Price100, source => source.MapFrom(dest => dest.Price100));

            CreateMap<ColorPrint, ColorPrintViewModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(dest => dest.Id))
                .ForMember(dest => dest.Price25, source => source.MapFrom(dest => dest.Price25))
                .ForMember(dest => dest.Price50, source => source.MapFrom(dest => dest.Price50))
                .ForMember(dest => dest.Price100, source => source.MapFrom(dest => dest.Price100));

        }
    }
}
