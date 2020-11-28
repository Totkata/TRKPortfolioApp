namespace TRKPortfolio.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using TRKPortfolio.Data.Common.Repositories;
    using TRKPortfolio.Data.Models;
    using TRKPortfolio.Services.Data.Contracts;
    using TRKPortfolio.Services.Mapping;
    using TRKPortfolio.Web.ViewModels.Administration.Projects.InputModel;
    using TRKPortfolio.Web.ViewModels.Projects.ViewModel;

    public class ProjectsService : IProjectsService
    {
        private readonly IDeletableEntityRepository<Project> projectRepo;
        private readonly IDeletableEntityRepository<Category> categoryRepo;
        private readonly IDeletableEntityRepository<Skill> skillRepo;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepo;

        public ProjectsService(
            IDeletableEntityRepository<Project> projectRepo,
            IDeletableEntityRepository<Category> categoryRepo,
            IDeletableEntityRepository<Skill> skillRepo,
            IDeletableEntityRepository<ApplicationUser> userRepo)
        {
            this.projectRepo = projectRepo;
            this.categoryRepo = categoryRepo;
            this.skillRepo = skillRepo;
            this.userRepo = userRepo;
        }

        public async Task CreateAsync(CreateProjectInputModel inputModel)
        {
            StringBuilder sb = new StringBuilder();

            int maxLenght = inputModel.Description.Length > 75 ? 75 : inputModel.Description.Length;
            sb.Append(inputModel.Description.Substring(0, maxLenght));
            sb.Append("...");

            var project = new Project
            {
                Title = inputModel.Title,
                Description = inputModel.Description,
                ShortDescription = sb.ToString(),
            };

            project.Customer = this.userRepo.All().FirstOrDefault(x => x.Id == inputModel.CustomerId.ToString());

            foreach (var inputCategory in inputModel.SkillId)
            {
                var skill = this.skillRepo.All().FirstOrDefault(x => x.Id == inputCategory);

                project.ProjectSkills.Add(new ProjectSkill
                {
                    Skill = skill,
                });
            }

            foreach (var inputCategory in inputModel.CategoryId)
            {
                var category = this.categoryRepo.All().FirstOrDefault(x => x.Id == inputCategory);

                project.ProjectCategories.Add(new ProjectCategory
                {
                    Category = category,
                });
            }

            var splitedInput = inputModel.Text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < splitedInput.Length; i += 2)
            {
                project.ProjectParagraphs.Add(new ProjectParagraph
                {
                    Paragraph = new Paragraph
                    {
                        Title = splitedInput[i],
                        Content = splitedInput[i + 1],
                    },
                });
            }

            await this.projectRepo.AddAsync(project);
            await this.projectRepo.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            var projects = this.projectRepo.AllAsNoTracking()
               .To<T>().ToList();
            return projects;
        }

        public T GetById<T>(int id)
        {
            var project = this.projectRepo.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return project;
        }
    }
}
