using DataLib;
using DataLib.Entities.Poligraph;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace React3x4.Seeder.PoligraphSeeder
{
    public static class BanerSeedData
    {
        public static void BanerSeeder(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();

            if (!context.Baners.Any())
            {
                context.Baners
                    .Add(new Baner
                    {
                        Dpi = "720 dpi",
                        Service = "Звичайний односторонній",
                        Price = 318
                    });

                context.Baners
                    .Add(new Baner
                    {
                        Dpi = "720 dpi",
                        Service = "+ люверси по периметру",
                        Price = 372
                    });

                context.Baners
                    .Add(new Baner
                    {
                        Dpi = "720 dpi",
                        Service = "+ проклейка всього підворота",
                        Price = 519
                    });

                context.Baners
                    .Add(new Baner
                    {
                        Dpi = "1080 dpi",
                        Service = "Звичайний односторонній",
                        Price = 335
                    });

                context.Baners
                    .Add(new Baner
                    {
                        Dpi = "1080 dpi",
                        Service = "+ люверси по периметру",
                        Price = 388
                    });

                context.Baners
                    .Add(new Baner
                    {
                        Dpi = "1080 dpi",
                        Service = "+ проклейка всього підворота",
                        Price = 534
                    });

                context.Baners
                    .Add(new Baner
                    {
                        Dpi = "1440 dpi",
                        Service = "Звичайний односторонній",
                        Price = 362
                    });

                context.Baners
                    .Add(new Baner
                    {
                        Dpi = "1440 dpi",
                        Service = "+ люверси по периметру",
                        Price = 417
                    });

                context.Baners
                    .Add(new Baner
                    {
                        Dpi = "1440 dpi",
                        Service = "+ проклейка всього підворота",
                        Price = 563
                    });

                context.Baners
                    .Add(new Baner
                    {
                        Dpi = "1440 dpi фото",
                        Service = "Звичайний односторонній",
                        Price = 427
                    });

                context.Baners
                    .Add(new Baner
                    {
                        Dpi = "1440 dpi фото",
                        Service = "+ люверси по периметру",
                        Price = 481
                    });

                context.Baners
                    .Add(new Baner
                    {
                        Dpi = "1440 dpi фото",
                        Service = "+ проклейка всього підворота",
                        Price = 627
                    });

                context.SaveChanges();
            }
        }
    }
}
