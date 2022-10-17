using DataLib;
using DataLib.Entities.Poligraph;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace React3x4.Seeder.PoligraphSeeder
{
    public static class CalendarSeedData
    {
        public static void CalendarSeeder(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();

            if (!context.Calendars.Any())
            {
                context.Calendars
                    .Add(new Calendar
                    {
                        Density = "250",
                        Laminating = "відсутнє",
                        Price = 848
                    });

                context.Calendars
                    .Add(new Calendar
                    {
                        Density = "300",
                        Laminating = "відсутнє",
                        Price = 977
                    });

                context.Calendars
                    .Add(new Calendar
                    {
                        Density = "350",
                        Laminating = "відсутнє",
                        Price = 1109
                    });

                context.Calendars
                    .Add(new Calendar
                    {
                        Density = "350",
                        Laminating = "Глянцеве 1+0",
                        Price = 1312
                    });

                context.Calendars
                    .Add(new Calendar
                    {
                        Density = "350",
                        Laminating = "Глянцеве 1+1",
                        Price = 1475
                    });

                context.SaveChanges();
            }
        }
    }
}
