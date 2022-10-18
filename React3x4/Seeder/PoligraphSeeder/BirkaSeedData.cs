using DataLib;
using DataLib.Entities.Poligraph;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace React3x4.Seeder.PoligraphSeeder
{
    public static class BirkaSeedData
    {
        public static void BirkaSeeder(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();

            if (!context.Birkas.Any())
            {
                context.Birkas
                    .Add(new Birka
                    {
                        Format = "30x50",
                        Density = "250",
                        Price = 272
                    });

                context.Birkas
                    .Add(new Birka
                    {
                        Format = "30x50",
                        Density = "300",
                        Price = 299
                    });

                context.Birkas
                    .Add(new Birka
                    {
                        Format = "30x50",
                        Density = "350",
                        Price = 330
                    });

                

                context.Birkas
                    .Add(new Birka
                    {
                        Format = "45x50",
                        Density = "250",
                        Price = 349
                    });

                context.Birkas
                    .Add(new Birka
                    {
                        Format = "45x50",
                        Density = "300",
                        Price = 391
                    });

                context.Birkas
                    .Add(new Birka
                    {
                        Format = "45x50",
                        Density = "350",
                        Price = 439
                    });

                context.Birkas
                    .Add(new Birka
                    {
                        Format = "50x70",
                        Density = "250",
                        Price = 495
                    });

                context.Birkas
                    .Add(new Birka
                    {
                        Format = "50x70",
                        Density = "300",
                        Price = 556
                    });

                context.Birkas
                    .Add(new Birka
                    {
                        Format = "50x70",
                        Density = "350",
                        Price = 626
                    });

                context.SaveChanges();
            }
        }
    }
}
