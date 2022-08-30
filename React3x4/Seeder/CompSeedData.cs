using DataLib;
using DataLib.Entities.Comp;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace React3x4.Seeder
{
    public static class CompSeedData
    {
        public static void XeroxSeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();

            if (!context.Xeroxes.Any())
            {
                context.Xeroxes
                    .Add(new Xerox
                    {
                        Name = "Односторонній",
                        Price = 2
                    });
                
                context.Xeroxes
                    .Add(new Xerox
                    {
                        Name = "Двосторонній",
                        Price = 3
                    });

                context.Xeroxes
                    .Add(new Xerox
                    {
                        Name = "Паспорт (3 стор.)",
                        Price = 4
                    });
                
                context.Xeroxes
                    .Add(new Xerox
                    {
                        Name = "Паспорт (4 стор.)",
                        Price = 5
                    });

                context.SaveChanges();
            }
        }
    }
}
