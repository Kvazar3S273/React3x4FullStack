using DataLib;
using DataLib.Entities.Photo;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;

namespace React3x4.Seeder
{
    public static class PhotoSeedData
    {
        public static void FndSeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();

            if (!context.Fnds.Any())
            {
                context.Fnds
                    .Add(new Fnd
                    {
                        Title = "Паспорт Посвідчення водія Медична довідка Фото абітурієнта Інші посвідчення",
                        Qty = 2,
                        Price = 60,
                        ArchivePice = 40
                    });

                context.Fnds
                    .Add(new Fnd
                    {
                        Title = "Пенсійне посвідчення Фото 4х6",
                        Qty = 2,
                        Price = 60,
                        ArchivePice = 40
                    });
                
                context.Fnds
                    .Add(new Fnd
                    {
                        Title = "Учнівський квиток",
                        Qty = 2,
                        Price = 55,
                        ArchivePice = 35
                    });

                context.Fnds
                    .Add(new Fnd
                    {
                        Title = "Віза Дитячий проїзний за кордон Посвідка на ПМП",
                        Qty = 2,
                        Price = 70,
                        ArchivePice = 48
                    });
                
                context.Fnds
                    .Add(new Fnd
                    {
                        Title = "Віза США Грін карта",
                        Qty = 1,
                        Price = 80,
                        ArchivePice = 56
                    });
                
                context.Fnds
                    .Add(new Fnd
                    {
                        Title = "Спеціальний формат 9х12 9х13 10х15",
                        Qty = 1,
                        Price = 60,
                        ArchivePice = 40
                    });
               
                context.SaveChanges();
            }
        }

        public static void PhotoPrintSeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();

            if (!context.Fotoprints.Any())
            {
                context.Fotoprints
                    .Add(new Photoprint
                    {
                        Format = "10х15",
                        ExactSizes = "102х152",
                        Price = 5
                    });
                context.Fotoprints
                    .Add(new Photoprint
                    {
                        Format = "13х18",
                        ExactSizes = "127х178",
                        Price = 10
                    });
                context.Fotoprints
                    .Add(new Photoprint
                    {
                        Format = "15х21",
                        ExactSizes = "152х216",
                        Price = 11
                    });
                context.Fotoprints
                    .Add(new Photoprint
                    {
                        Format = "20х30",
                        ExactSizes = "203х305",
                        Price = 21
                    });
                context.Fotoprints
                    .Add(new Photoprint
                    {
                        Format = "30х40",
                        ExactSizes = "305х420",
                        Price = 42
                    });

                context.SaveChanges();
            }
        }

        public static void PhotoScanSeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();

            if (!context.Photoscans.Any())
            {
                context.Photoscans
                    .Add(new PhotoScan
                    {
                        Format = "На документи",
                        Price1200dpi = 15
                    });
                context.Photoscans
                    .Add(new PhotoScan
                    {
                        Format = "10х15",
                        Price300dpi = 5,
                        Price600dpi = 9,
                        Price1200dpi = 15
                    });
                context.Photoscans
                    .Add(new PhotoScan
                    {
                        Format = "15х21",
                        Price300dpi = 8,
                        Price600dpi = 14,
                        Price1200dpi = 24
                    });
                context.Photoscans
                    .Add(new PhotoScan
                    {
                        Format = "20х30",
                        Price300dpi = 10,
                        Price600dpi = 17
                    });


                context.SaveChanges();
            }
        }
    }
}
