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
                .ForMember(dest => dest.Name, source => source.MapFrom(dest => dest.Name))
                .ForMember(dest => dest.Price, source => source.MapFrom(dest => dest.Price));

            CreateMap<BlackPrint, BlackPrintViewModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(dest => dest.Id))
                .ForMember(dest => dest.Material, source => source.MapFrom(dest => dest.Material))
                .ForMember(dest => dest.PriceText, source => source.MapFrom(dest => dest.PriceText))
                .ForMember(dest => dest.Price100, source => source.MapFrom(dest => dest.Price100));

            CreateMap<ColorPrint, ColorPrintViewModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(dest => dest.Id))
                .ForMember(dest => dest.Material, source => source.MapFrom(dest => dest.Material))
                .ForMember(dest => dest.Price25, source => source.MapFrom(dest => dest.Price25))
                .ForMember(dest => dest.Price50, source  => source.MapFrom(dest => dest.Price50))
                .ForMember(dest => dest.Price100, source => source.MapFrom(dest => dest.Price100));

            CreateMap<Scanning, ScanningsViewModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(dest => dest.Id))
                .ForMember(dest => dest.Service, source => source.MapFrom(dest => dest.Service))
                .ForMember(dest => dest.Price, source => source.MapFrom(dest => dest.Price));

            CreateMap<Laminate, LaminatesViewModel>()
                .ForMember(dest => dest.Id, source => source.MapFrom(dest => dest.Id))
                .ForMember(dest => dest.Format, source => source.MapFrom(dest => dest.Format))
                .ForMember(dest => dest.Price, source => source.MapFrom(dest => dest.Price));

        }
    }
}
