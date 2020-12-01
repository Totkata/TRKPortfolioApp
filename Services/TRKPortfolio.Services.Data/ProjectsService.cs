namespace TRKPortfolio.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using TRKPortfolio.Data.Common.Repositories;
    using TRKPortfolio.Data.Models;
    using TRKPortfolio.Services.Data.Contracts;
    using TRKPortfolio.Services.Mapping;
    using TRKPortfolio.Web.ViewModels.Administration.Projects.InputModel;
    using TRKPortfolio.Web.ViewModels.Projects.ViewModel;
    using TRKPortfolio.Web.ViewModels.Testimonials.InputModel;

    public class ProjectsService : IProjectsService
    {
        private readonly IDeletableEntityRepository<Project> projectRepo;
        private readonly IDeletableEntityRepository<Category> categoryRepo;
        private readonly IDeletableEntityRepository<Skill> skillRepo;
        private readonly IDeletableEntityRepository<Testimonial> testimonialRepo;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepo;

        public ProjectsService(
            IDeletableEntityRepository<Project> projectRepo,
            IDeletableEntityRepository<Category> categoryRepo,
            IDeletableEntityRepository<Skill> skillRepo,
            IDeletableEntityRepository<Testimonial> testimonialRepo,
            IDeletableEntityRepository<ApplicationUser> userRepo)
        {
            this.projectRepo = projectRepo;
            this.categoryRepo = categoryRepo;
            this.skillRepo = skillRepo;
            this.testimonialRepo = testimonialRepo;
            this.userRepo = userRepo;
        }

        public async Task CreateAsync(CreateProjectInputModel inputModel)
        {
            var project = new Project
            {
                Title = inputModel.Title,
                Description = inputModel.Description,
                ShortDescription = ShortDescriptionParser(inputModel.Description),
            };

            project.Customer = this.userRepo.All().FirstOrDefault(x => x.Id == inputModel.CustomerId.ToString());

            SkillsHandeller(inputModel.CategoryId, project, this.skillRepo);

            CategoriesHandeller(inputModel.CategoryId, project, this.categoryRepo);

            ParagraphParser(inputModel.Text, project);

            await this.projectRepo.AddAsync(project);
            await this.projectRepo.SaveChangesAsync();
        }

        public async Task EditAsync(EditProjectInputModel inputModel)
        {
            var project = this.projectRepo
                .All()
                .Include(p => p.Paragraphs)
                .ThenInclude(p => p.Paragraph)
                .Include(p => p.ProjectSkills)
                .ThenInclude(p => p.Skill)
                .Include(p => p.ProjectCategories)
                .ThenInclude(p => p.Category)
                .FirstOrDefault(x => x.Id == inputModel.Id);

            project.Title = inputModel.Title;
            project.Description = inputModel.Description;

            project.Paragraphs.Clear();
            ParagraphParser(inputModel.Text, project);

            project.Description = inputModel.Description;
            project.ShortDescription = ShortDescriptionParser(inputModel.Description);

            project.ProjectCategories.Clear();
            CategoriesHandeller(inputModel.CategoryId, project, this.categoryRepo);

            project.ProjectSkills.Clear();
            SkillsHandeller(inputModel.CategoryId, project, this.skillRepo);

            await this.projectRepo.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var post = await this.projectRepo.GetByIdWithDeletedAsync(id);

            this.projectRepo.Delete(post);

            await this.projectRepo.SaveChangesAsync();
        }

        public async Task AddTestimonialAsyncAsync(CreateTestimonialInputModel input)
        {
            var project = this.projectRepo.AllAsNoTracking().Where(x => x.Id == input.Id).FirstOrDefault();

            var testimonial = new Testimonial
            {
                Text = input.Text,
                Rating = new Rating
                {
                    WorkRating = input.WorkQualityRating,
                    SkillRating = input.SkillRating,
                    DeadlineRating = input.DeadlineRating,
                    CooperatingRating = input.CooperatingRating,
                    AvaliabilityRating = input.AvaliabilityRating,
                    ComunicationRating = input.ComunicationRating,
                },
                ProjectId = project.Id,
            };

            await this.testimonialRepo.AddAsync(testimonial);
            await this.testimonialRepo.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            var projects = this.projectRepo.AllAsNoTracking()
               .To<T>().ToList();
            return projects;
        }

        public IEnumerable<T> GetAllTestimonials<T>()
        {
            var testimonials = this.testimonialRepo.AllAsNoTracking()
               .To<T>().ToList();
            return testimonials;
        }

        public T GetById<T>(int id)
        {
            var project = this.projectRepo.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return project;
        }

        private static void ParagraphParser(string input, Project project)
        {
            var splitedInput = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < splitedInput.Length; i += 2)
            {
                project.Paragraphs.Add(new ProjectParagraph
                {
                    Paragraph = new Paragraph
                    {
                        Title = splitedInput[i],
                        Content = splitedInput[i + 1],
                    },
                });
            }
        }

        private static string ShortDescriptionParser(string input)
        {
            StringBuilder sb = new StringBuilder();

            int maxLenght = input.Length > 75 ? 75 : input.Length;
            sb.Append(input.Substring(0, maxLenght));
            sb.Append("...");

            return sb.ToString();
        }

        private static void CategoriesHandeller(int[] input, Project project, IDeletableEntityRepository<Category> categoryRepo)
        {
            foreach (var inputCategory in input)
            {
                var category = categoryRepo.All().FirstOrDefault(x => x.Id == inputCategory);

                project.ProjectCategories.Add(new ProjectCategory
                {
                    Category = category,
                });
            }
        }

        private static void SkillsHandeller(int[] input, Project project, IDeletableEntityRepository<Skill> skillRepo)
        {
            foreach (var inputCategory in input)
            {
                var skill = skillRepo.All().FirstOrDefault(x => x.Id == inputCategory);

                project.ProjectSkills.Add(new ProjectSkill
                {
                    Skill = skill,
                });
            }
        }
    }
}
