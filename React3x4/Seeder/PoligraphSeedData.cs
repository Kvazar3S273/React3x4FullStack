using DataLib;
using DataLib.Entities.Poligraph;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace React3x4.Seeder
{
    public static class PoligraphSeedData
    {
        public static void VisitcardSeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();

            if (!context.Visitcards.Any())
            {
                context.Visitcards
                    .Add(new Visitcard
                    {
                        Density = "250",
                        Laminating = "відсутнє",
                        Price = 500
                    });

                context.Visitcards
                    .Add(new Visitcard
                    {
                        Density = "350",
                        Laminating = "відсутнє",
                        Price = 540
                    });

                context.Visitcards
                    .Add(new Visitcard
                    {
                        Density = "350",
                        Laminating = "Глянцеве 1+0",
                        Price = 580
                    });

                context.Visitcards
                    .Add(new Visitcard
                    {
                        Density = "350",
                        Laminating = "Глянцеве 1+1",
                        Price = 610
                    });

                context.Visitcards
                    .Add(new Visitcard
                    {
                        Density = "350",
                        Laminating = "Матове 1+1",
                        Price = 700
                    });

                context.Visitcards
                    .Add(new Visitcard
                    {
                        Density = "350",
                        Laminating = "УФ лак 1+0",
                        Price = 590
                    });

                context.Visitcards
                    .Add(new Visitcard
                    {
                        Density = "350",
                        Laminating = "Soft-touch 1+0",
                        Price = 780
                    });

                context.Visitcards
                    .Add(new Visitcard
                    {
                        Density = "450",
                        Laminating = "Soft-touch 1+1",
                        Price = 960
                    });

                context.SaveChanges();
            }
        }

        public static void VisitkaSeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();

            if (!context.Visitkas.Any())
            {
                context.Visitkas
                    .Add(new Visitka
                    {
                        Density = "250",
                        Laminating = "відсутнє",
                        Price = 500
                    });

                context.Visitkas
                    .Add(new Visitka
                    {
                        Density = "350",
                        Laminating = "відсутнє",
                        Price = 540
                    });

                context.Visitkas
                    .Add(new Visitka
                    {
                        Density = "350",
                        Laminating = "Глянцеве 1+0",
                        Price = 580
                    });

                context.Visitkas
                    .Add(new Visitka
                    {
                        Density = "350",
                        Laminating = "Глянцеве 1+1",
                        Price = 610
                    });

                context.Visitkas
                    .Add(new Visitka
                    {
                        Density = "350",
                        Laminating = "Матове 1+1",
                        Price = 700
                    });

                context.Visitkas
                    .Add(new Visitka
                    {
                        Density = "350",
                        Laminating = "УФ лак 1+0",
                        Price = 590
                    });

                context.Visitkas
                    .Add(new Visitka
                    {
                        Density = "350",
                        Laminating = "Soft-touch 1+0",
                        Price = 780
                    });

                context.Visitkas
                    .Add(new Visitka
                    {
                        Density = "450",
                        Laminating = "Soft-touch 1+1",
                        Price = 960
                    });

                context.SaveChanges();
            }
        }
    }
}
