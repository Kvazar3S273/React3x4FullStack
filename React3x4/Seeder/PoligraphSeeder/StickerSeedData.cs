using DataLib;
using DataLib.Entities.Poligraph;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace React3x4.Seeder.PoligraphSeeder
{
    public static class StickerSeedData
    {
        public static void StickerSeeder(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();

            if (!context.Stickers.Any())
            {
                context.Stickers
                    .Add(new Sticker
                    {
                        Format = "50x50",
                        Qty = "100",
                        Price = 209
                    });

                context.Stickers
                    .Add(new Sticker
                    {
                        Format = "50x50",
                        Qty = "250",
                        Price = 311
                    });

                context.Stickers
                    .Add(new Sticker
                    {
                        Format = "50x50",
                        Qty = "500",
                        Price = 488
                    });

                context.Stickers
                    .Add(new Sticker
                    {
                        Format = "50x50",
                        Qty = "1000",
                        Price = 644
                    });

                context.Stickers
                    .Add(new Sticker
                    {
                        Format = "Круг діам. 50",
                        Qty = "100",
                        Price = 264
                    });

                context.Stickers
                    .Add(new Sticker
                    {
                        Format = "Круг діам. 50",
                        Qty = "250",
                        Price = 444
                    });

                context.Stickers
                    .Add(new Sticker
                    {
                        Format = "Круг діам. 50",
                        Qty = "500",
                        Price = 755
                    });

                context.Stickers
                    .Add(new Sticker
                    {
                        Format = "Круг діам. 50",
                        Qty = "1000",
                        Price = 1143
                    });

                context.SaveChanges();
            }
        }
    }
}
