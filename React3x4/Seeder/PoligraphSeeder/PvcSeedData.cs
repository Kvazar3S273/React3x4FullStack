using DataLib;
using DataLib.Entities.Poligraph;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace React3x4.Seeder.PoligraphSeeder
{
    public static class PvcSeedData
    {
        public static void PvcSeeder(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();

            if (!context.Pvcs.Any())
            {
                context.Pvcs
                    .Add(new Pvc
                    {
                        Thickness = "3 мм",
                        Price = 318
                    });

                context.Pvcs
                    .Add(new Pvc
                    {
                        Thickness = "4 мм",
                        Price = 342
                    });

                context.Pvcs
                    .Add(new Pvc
                    {
                        Thickness = "5 мм",
                        Price = 396
                    });

                context.Pvcs
                    .Add(new Pvc
                    {
                        Thickness = "6 мм",
                        Price = 515
                    });

                context.Pvcs
                    .Add(new Pvc
                    {
                        Thickness = "8 мм",
                        Price = 566
                    });

                context.Pvcs
                    .Add(new Pvc
                    {
                        Thickness = "10 мм",
                        Price = 619
                    });

                context.SaveChanges();
            }
        }
    }
}
