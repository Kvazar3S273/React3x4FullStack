using DataLib.Entities.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using React3x4.Constants;
using System.Linq;
using System.Threading.Tasks;

namespace React3x4.Seeder
{
    public static class AdminSeedData
    {
        public static async Task SeedData(this IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
            var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            if (!userManager.Users.Any())
            {
                var role = new AppRole
                {
                    Name = Roles.Admin
                };
                var result1 = roleManager.CreateAsync(role).Result;

                var user = new AppUser
                {
                    Email = "firstuser@ukr.net",
                    UserName = "firstuser@ukr.net"
                };
                var res = await userManager.CreateAsync(user, "w3hev");
                res = await userManager.AddToRoleAsync(user, Roles.Admin);
            }

        }
    }
}
