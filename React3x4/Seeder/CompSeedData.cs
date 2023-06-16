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

        public static void BlackPrintSeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();

            if (!context.BlackPrints.Any())
            {
                context.BlackPrints
                    .Add(new BlackPrint
                    {
                        Material = "Звичайний папір",
                        PriceText = 2,
                        Price100 = 4
                    });

                context.BlackPrints
                    .Add(new BlackPrint
                    {
                        Material = "Цупкий папір",
                        PriceText = 4,
                        Price100 = 7
                    });

                context.BlackPrints
                    .Add(new BlackPrint
                    {
                        Material = "Кольоровий папір",
                        PriceText = 5,
                        Price100 = 8
                    });

                context.BlackPrints
                    .Add(new BlackPrint
                    {
                        Material = "Кольоровий картон",
                        PriceText = 6,
                        Price100 = 9
                    });

                context.SaveChanges();
            }
        }

        public static void ColorPrintSeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();

            if (!context.ColorPrints.Any())
            {
                context.ColorPrints
                    .Add(new ColorPrint
                    {
                        Material = "Звичайний папір",
                        Price25 = 7,
                        Price50 = 8,
                        Price100 = 9
                    });

                context.ColorPrints
                    .Add(new ColorPrint
                    {
                        Material = "Цупкий папір",
                        Price25 = 9,
                        Price50 = 10,
                        Price100 = 11
                    });

                context.ColorPrints
                    .Add(new ColorPrint
                    {
                        Material = "Кольоровий папір",
                        Price25 = 9,
                        Price50 = 10,
                        Price100 = 11
                    });

                context.ColorPrints
                    .Add(new ColorPrint
                    {
                        Material = "Кольоровий картон",
                        Price25 = 10,
                        Price50 = 11,
                        Price100 = 12
                    });

                context.ColorPrints
                    .Add(new ColorPrint
                    {
                        Material = "Самоклейка звичайна",
                        Price25 = 12,
                        Price50 = 12,
                        Price100 = 12
                    });

                context.ColorPrints
                    .Add(new ColorPrint
                    {
                        Material = "Фотопапір тонкий",
                        Price25 = 16,
                        Price50 = 16,
                        Price100 = 16
                    });

                context.ColorPrints
                    .Add(new ColorPrint
                    {
                        Material = "Фотопапір цупкий",
                        Price25 = 18,
                        Price50 = 18,
                        Price100 = 18
                    });

                context.ColorPrints
                    .Add(new ColorPrint
                    {
                        Material = "Фотопапір самоклейка",
                        Price25 = 20,
                        Price50 = 20,
                        Price100 = 20
                    });

                context.SaveChanges();
            }
        }

        public static void ScanningSeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();

            if (!context.Scannings.Any())
            {
                context.Scannings
                    .Add(new Scanning
                    {
                        Service = "Кольорове сканування",
                        Price = 5
                    });

                context.Scannings
                    .Add(new Scanning
                    {
                        Service = "Відправка 1 листа на e-mail",
                        Price = 10
                    });

                context.Scannings
                    .Add(new Scanning
                    {
                        Service = "Відправка документа на Viber",
                        Price = 5
                    });

                context.SaveChanges();
            }
        }

        public static void LaminateSeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();

            if (!context.Laminates.Any())
            {
                context.Laminates
                    .Add(new Laminate
                    {
                        Format = "А4, 20х30, свідоцтва",
                        Price = 20
                    });

                context.Laminates
                    .Add(new Laminate
                    {
                        Format = "А4, 125 мкм",
                        Price = 30
                    });

                context.Laminates
                    .Add(new Laminate
                    {
                        Format = "А5, 15х21",
                        Price = 17
                    });

                context.Laminates
                    .Add(new Laminate
                    {
                        Format = "А6, 10х15",
                        Price = 15
                    });

                context.Laminates
                    .Add(new Laminate
                    {
                        Format = "менше за А6",
                        Price = 12
                    });

                context.SaveChanges();
            }
        }

        public static void BinderSeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();

            if (!context.Binders.Any())
            {
                context.Binders
                    .Add(new Binder
                    {
                        PagesQty = "до 20",
                        Price = 30
                    });

                context.Binders
                    .Add(new Binder
                    {
                        PagesQty = "21-40",
                        Price = 35
                    });

                context.Binders
                   .Add(new Binder
                   {
                       PagesQty = "41-60",
                       Price = 40
                   });

                context.Binders
                    .Add(new Binder
                    {
                        PagesQty = "61-80",
                        Price = 45
                    });

                context.Binders
                   .Add(new Binder
                   {
                       PagesQty = "кожних +20 сторінок, +...грн",
                       Price = 5
                   });

                context.Binders
                    .Add(new Binder
                    {
                        PagesQty = "додавання сторінок (10 шт), від",
                        Price = 8
                    });

                context.SaveChanges();
            }
        }

        public static void UsbFlashSeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();

            if (!context.UsbFlashes.Any())
            {
                context.UsbFlashes
                    .Add(new UsbFlash
                    {
                        Service = "Запис CD дисків 700 Mb",
                        Price = 20
                    });

                context.UsbFlashes
                    .Add(new UsbFlash
                    {
                        Service = "Запис DVD дисків 4,7 Gb",
                        Price = 25
                    });

                context.UsbFlashes
                    .Add(new UsbFlash
                    {
                        Service = "Запис DVD-DL дисків 8,5 Gb",
                        Price = 30
                    });

                context.UsbFlashes
                    .Add(new UsbFlash
                    {
                        Service = "Запис флеш-носіїв до 8 Gb",
                        Price = 30
                    });

                context.UsbFlashes
                    .Add(new UsbFlash
                    {
                        Service = "Запис флеш-носіїв більше 8 Gb",
                        Price = 40
                    });

                context.SaveChanges();
            }
        }

        public static void VhsSeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();

            if (!context.Vhses.Any())
            {
                context.Vhses
                    .Add(new Vhs
                    {
                        Service = "Оцифровка першої години запису",
                        Price = 100
                    });
                context.Vhses
                    .Add(new Vhs
                    {
                        Service = "Оцифровка одної години запису при умові знижки",
                        Price = 85
                    });
                context.SaveChanges();
            }
        }

        public static void DiscprintSeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();

            if (!context.Discprints.Any())
            {
                context.Discprints
                    .Add(new Discprint
                    {
                        Service = "Друк на диску",
                        Price = 40
                    });

                context.Discprints
                   .Add(new Discprint
                   {
                       Service = "Розробка макету, від",
                       Price = 50
                   });

                context.SaveChanges();
            }
        }

        public static void EmailSeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();

            if (!context.Emails.Any())
            {
                context.Emails
                    .Add(new Email
                    {
                        Service = "Відправка ел. пошти, за 1 лист",
                        Price = 10
                    });

                context.Emails
                     .Add(new Email
                     {
                       Service = "Відправка на Viber",
                       Price = 5
                   });

                context.Emails
                    .Add(new Email
                    {
                        Service = "Використання вашої скриньки",
                        Price = 15
                    });

                context.Emails
                    .Add(new Email
                    {
                       Service = "Завантаження на файлообмінник, від",
                       Price = 50
                   });

                context.SaveChanges();
            }
        }

        public static void TestSeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppEFContext>();

            if (!context.Tests.Any())
            {
                context.Tests
                    .Add(new Test
                    {
                        Name="Сканування",
                        DealerPrice=10,
                        UserPrice=0,
                        AlternatePrice=0
                    });

                context.Tests
                    .Add(new Test
                    {
                        Name = "Друк",
                        DealerPrice = 11,
                        UserPrice = 0,
                        AlternatePrice = 0
                    });

                context.Tests
                    .Add(new Test
                    {
                        Name = "Брошурування",
                        DealerPrice = 12,
                        UserPrice = 0,
                        AlternatePrice = 0
                    });

                context.Tests
                    .Add(new Test
                    {
                        Name = "Ламінування",
                        DealerPrice = 13,
                        UserPrice = 0,
                        AlternatePrice = 0
                    });

                context.Tests
                    .Add(new Test
                    {
                        Name = "Порізка",
                        DealerPrice = 14,
                        UserPrice = 0,
                        AlternatePrice = 0
                    });

                context.SaveChanges();
            }
        }
    }
}
