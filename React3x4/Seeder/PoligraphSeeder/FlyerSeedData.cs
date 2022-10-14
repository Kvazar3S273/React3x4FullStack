using DataLib;
using DataLib.Entities.Poligraph;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace React3x4.Seeder.PoligraphSeeder
{
    public static class FlyerSeedData
    {
        public static void FlyerSeeder(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();

            if (!context.Flyers.Any())
            {
                context.Flyers
                    .Add(new Flyer
                    {
                        Format = "Єврофлаєр",
                        Qty = "1000",
                        Price = 1216
                    });
                
                context.Flyers
                    .Add(new Flyer
                    {
                        Format = "Єврофлаєр",
                        Qty = "2500",
                        Price = 2013
                    });
                
                context.Flyers
                    .Add(new Flyer
                    {
                        Format = "Єврофлаєр",
                        Qty = "5000",
                        Price = 2867
                    });

                context.Flyers
                    .Add(new Flyer
                    {
                        Format = "A6",
                        Qty = "1000",
                        Price = 1054
                    });
                
                context.Flyers
                    .Add(new Flyer
                    {
                        Format = "A6",
                        Qty = "2500",
                        Price = 1720
                    });
                
                context.Flyers
                    .Add(new Flyer
                    {
                        Format = "A6",
                        Qty = "5000",
                        Price = 2459
                    });
                
                context.Flyers
                    .Add(new Flyer
                    {
                        Format = "A5",
                        Qty = "1000",
                        Price = 1904
                    });
                
                context.Flyers
                    .Add(new Flyer
                    {
                        Format = "A5",
                        Qty = "2500",
                        Price = 3290
                    });
                
                context.Flyers
                    .Add(new Flyer
                    {
                        Format = "A5",
                        Qty = "5000",
                        Price = 4707
                    });

                context.SaveChanges();
            }
        }
    }
}
