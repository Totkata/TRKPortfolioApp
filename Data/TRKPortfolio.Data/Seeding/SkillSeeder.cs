namespace TRKPortfolio.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using TRKPortfolio.Data.Models;

    internal class SkillSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Skills.Any())
            {
                return;
            }

            await dbContext.Skills.AddAsync(new Skill { SkillTitle = ".NET 5" });
            await dbContext.Skills.AddAsync(new Skill { SkillTitle = "Web API" });
            await dbContext.Skills.AddAsync(new Skill { SkillTitle = "MVC" });
            await dbContext.Skills.AddAsync(new Skill { SkillTitle = "Angular.js" });
            await dbContext.Skills.AddAsync(new Skill { SkillTitle = "TypeScript" });
            await dbContext.Skills.AddAsync(new Skill { SkillTitle = "JavaScript" });
            await dbContext.Skills.AddAsync(new Skill { SkillTitle = "CSS" });
            await dbContext.Skills.AddAsync(new Skill { SkillTitle = "HTML" });
            await dbContext.Skills.AddAsync(new Skill { SkillTitle = "Responsive Design" });
            await dbContext.Skills.AddAsync(new Skill { SkillTitle = "Debugging" });
            await dbContext.Skills.AddAsync(new Skill { SkillTitle = "Testing" });
            await dbContext.Skills.AddAsync(new Skill { SkillTitle = "CMS" });
            await dbContext.Skills.AddAsync(new Skill { SkillTitle = "GIT" });
            await dbContext.Skills.AddAsync(new Skill { SkillTitle = "Problem-solving" });
            await dbContext.Skills.AddAsync(new Skill { SkillTitle = "SEO" });
            await dbContext.Skills.AddAsync(new Skill { SkillTitle = "Copywrite" });
            await dbContext.Skills.AddAsync(new Skill { SkillTitle = "UX Design" });
            await dbContext.Skills.AddAsync(new Skill { SkillTitle = "UI Design" });
            await dbContext.Skills.AddAsync(new Skill { SkillTitle = "Logo Design" });
            await dbContext.Skills.AddAsync(new Skill { SkillTitle = "Branding" });
            await dbContext.Skills.AddAsync(new Skill { SkillTitle = "Marketing" });
        }
    }
}
