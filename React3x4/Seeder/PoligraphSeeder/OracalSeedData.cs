using DataLib;
using DataLib.Entities.Poligraph;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace React3x4.Seeder.PoligraphSeeder
{
    public static class OracalSeedData
    {
        public static void OracalSeeder(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();

            if (!context.Oracals.Any())
            {
                context.Oracals
                    .Add(new Oracal
                    {
                        Tape = "Біла",
                        Laminating = "відсутня",
                        Price = 359
                    });

                context.Oracals
                    .Add(new Oracal
                    {
                        Tape = "Біла",
                        Laminating = "глянцева",
                        Price = 512
                    });

                context.Oracals
                    .Add(new Oracal
                    {
                        Tape = "Прозора",
                        Laminating = "відсутня",
                        Price = 328
                    });

                context.Oracals
                    .Add(new Oracal
                    {
                        Tape = "Прозора",
                        Laminating = "глянцева",
                        Price = 481
                    });

                context.Oracals
                    .Add(new Oracal
                    {
                        Tape = "Легкозйомна",
                        Laminating = "відсутня",
                        Price = 362
                    });

                context.Oracals
                    .Add(new Oracal
                    {
                        Tape = "Легкозйомна",
                        Laminating = "глянцева",
                        Price = 517
                    });

                context.Oracals
                    .Add(new Oracal
                    {
                        Tape = "One Way Vision",
                        Laminating = "відсутня",
                        Price = 396
                    });

                context.Oracals
                    .Add(new Oracal
                    {
                        Tape = "One Way Vision",
                        Laminating = "глянцева",
                        Price = 549
                    });

                context.Oracals
                    .Add(new Oracal
                    {
                        Tape = "Автомобільна",
                        Laminating = "відсутня",
                        Price = 474
                    });

                context.Oracals
                    .Add(new Oracal
                    {
                        Tape = "Підлогова",
                        Laminating = "відсутня",
                        Price = 474
                    });

                context.Oracals
                    .Add(new Oracal
                    {
                        Tape = "Підлогова",
                        Laminating = "глянцева",
                        Price = 1122
                    });

                context.SaveChanges();
            }
        }
    }
}
