using DataLib;
using DataLib.Entities.Poligraph;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace React3x4.Seeder.PoligraphSeeder
{
    public static class VisitcardSeedData
    {
        public static void VisitcardSeeder(this IApplicationBuilder app)
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
                        Price = 609
                    });

                context.Visitcards
                    .Add(new Visitcard
                    {
                        Density = "300",
                        Laminating = "відсутнє",
                        Price = 685
                    });

                context.Visitcards
                    .Add(new Visitcard
                    {
                        Density = "350",
                        Laminating = "відсутнє",
                        Price = 775
                    });

                context.Visitcards
                    .Add(new Visitcard
                    {
                        Density = "350",
                        Laminating = "Глянцеве 1+0",
                        Price = 876
                    });

                context.Visitcards
                    .Add(new Visitcard
                    {
                        Density = "350",
                        Laminating = "Глянцеве 1+1",
                        Price = 1011
                    });

                context.Visitcards
                    .Add(new Visitcard
                    {
                        Density = "350",
                        Laminating = "Матове 1+0",
                        Price = 894
                    });

                context.Visitcards
                    .Add(new Visitcard
                    {
                        Density = "350",
                        Laminating = "Матове 1+1",
                        Price = 1054
                    });

                context.Visitcards
                    .Add(new Visitcard
                    {
                        Density = "350",
                        Laminating = "Soft-touch 1+0",
                        Price = 1330
                    });

                context.Visitcards
                    .Add(new Visitcard
                    {
                        Density = "350",
                        Laminating = "Soft-touch 1+1",
                        Price = 1968
                    });

                context.Visitcards
                    .Add(new Visitcard
                    {
                        Density = "350",
                        Laminating = "Глянцевий УФ лак 1+0",
                        Price = 972
                    });

                context.Visitcards
                    .Add(new Visitcard
                    {
                        Density = "350",
                        Laminating = "Матовий УФ лак 1+0",
                        Price = 972
                    });

                context.Visitcards
                    .Add(new Visitcard
                    {
                        Density = "450",
                        Laminating = "відсутнє",
                        Price = 1082
                    });

                context.Visitcards
                    .Add(new Visitcard
                    {
                        Density = "450",
                        Laminating = "Глянцеве 1+0",
                        Price = 1238
                    });

                context.Visitcards
                    .Add(new Visitcard
                    {
                        Density = "450",
                        Laminating = "Глянцеве 1+1",
                        Price = 1301
                    });

                context.Visitcards
                    .Add(new Visitcard
                    {
                        Density = "450",
                        Laminating = "Матове 1+0",
                        Price = 1228
                    });

                context.Visitcards
                    .Add(new Visitcard
                    {
                        Density = "450",
                        Laminating = "Матове 1+1",
                        Price = 1342
                    });

                context.Visitcards
                    .Add(new Visitcard
                    {
                        Density = "450",
                        Laminating = "Soft-touch 1+0",
                        Price = 1798
                    });

                context.Visitcards
                    .Add(new Visitcard
                    {
                        Density = "450",
                        Laminating = "Soft-touch 1+1",
                        Price = 2554
                    });

                context.Visitcards
                    .Add(new Visitcard
                    {
                        Density = "350 - 50 шт",
                        Laminating = "Глянцеве 1+0",
                        Price = 206
                    });

                context.Visitcards
                    .Add(new Visitcard
                    {
                        Density = "350 - 100 шт",
                        Laminating = "Глянцеве 1+0",
                        Price = 289
                    });

                context.Visitcards
                    .Add(new Visitcard
                    {
                        Density = "350 - 200 шт",
                        Laminating = "Глянцеве 1+0",
                        Price = 452
                    });

                context.SaveChanges();
            }
        }
    }
}
