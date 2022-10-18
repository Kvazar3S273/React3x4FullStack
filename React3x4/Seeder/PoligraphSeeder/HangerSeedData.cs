using DataLib;
using DataLib.Entities.Poligraph;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace React3x4.Seeder.PoligraphSeeder
{
    public static class HangerSeedData
    {
        public static void HangerSeeder(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();

            if (!context.Hangers.Any())
            {
                context.Hangers
                    .Add(new Hanger
                    {
                        Qty = "1000",
                        Price = 2014
                    });

                context.Hangers
                    .Add(new Hanger
                    {
                        Qty = "2500",
                        Price = 3576
                    });

                context.Hangers
                    .Add(new Hanger
                    {
                        Qty = "5000",
                        Price = 5600
                    });

                context.SaveChanges();
            }
        }
    }
}
