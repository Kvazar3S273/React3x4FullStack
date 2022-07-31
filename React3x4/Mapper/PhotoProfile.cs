using AutoMapper;
using DataLib.Entities.Photo;
using React3x4.Mapper.MapperModels;

namespace React3x4.Mapper
{
    public class PhotoProfile: Profile
    {
        public PhotoProfile()
        {
            CreateMap<Fnd, FndsViewModel>().
                ForMember(dest => dest.Id, source => source.MapFrom(dest => dest.Id))
                .ForMember(dest => dest.Qty, source => source.MapFrom(dest => dest.Qty))
                .ForMember(dest => dest.Price, source => source.MapFrom(dest => dest.Price))
                .ForMember(dest => dest.ArchivePice, source => source.MapFrom(dest => dest.ArchivePice))
                .ForMember(dest => dest.Title, source => source.MapFrom(dest => dest.Title));

            CreateMap<Photoprint, FotoprintsViewModel>().
                ForMember(dest => dest.Id, source => source.MapFrom(dest => dest.Id))
                .ForMember(dest => dest.Format, source => source.MapFrom(dest => dest.Format))
                .ForMember(dest => dest.ExactSizes, source => source.MapFrom(dest => dest.ExactSizes))
                .ForMember(dest => dest.Price, source => source.MapFrom(dest => dest.Price));

        }
    }
}
