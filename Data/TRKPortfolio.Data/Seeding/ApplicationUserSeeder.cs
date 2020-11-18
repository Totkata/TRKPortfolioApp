namespace TRKPortfolio.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using TRKPortfolio.Data.Models;

    public class ApplicationUserSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedUserAsync(userManager, "Totkata", "Totk@ta990803", "toti1471123@gmail.com");
            await SeedUserToRole(userManager, "Totkata", "Admin");
        }

        private static async Task SeedUserAsync(UserManager<ApplicationUser> userManager, string username, string password, string email)
        {
            var user = await userManager.FindByNameAsync(username);

            if (user == null)
            {
                var result = await userManager.CreateAsync(
                    new ApplicationUser
                    {
                        UserName = username,
                        Email = email,
                        EmailConfirmed = true,
                    }, password);

                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }

        private static async Task SeedUserToRole(UserManager<ApplicationUser> userManager, string username, string roleName)
        {
            var user = await userManager.FindByNameAsync(username);

            await userManager.AddToRoleAsync(user, roleName);
        }
    }
}
