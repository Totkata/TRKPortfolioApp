namespace TRKPortfolio.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using TRKPortfolio.Data.Models;

    internal class CategorySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category { Name = "Frond-end" });
            await dbContext.Categories.AddAsync(new Category { Name = "Back-end" });
            await dbContext.Categories.AddAsync(new Category { Name = "UI Design" });
            await dbContext.Categories.AddAsync(new Category { Name = "UX Design" });
            await dbContext.Categories.AddAsync(new Category { Name = "Logo Design" });
            await dbContext.Categories.AddAsync(new Category { Name = "Brand Design" });
            await dbContext.Categories.AddAsync(new Category { Name = "Full-stack Development" });
            await dbContext.Categories.AddAsync(new Category { Name = "Full-stack Design" });
        }
    }
}
