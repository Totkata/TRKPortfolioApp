namespace TRKPortfolio.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using TRKPortfolio.Data.Common.Repositories;
    using TRKPortfolio.Data.Models;
    using TRKPortfolio.Services.Data.Contracts;
    using TRKPortfolio.Web.ViewModels.Testimonials.InputModel;

    public class TestimonialsService : ITestimonialsService
    {
        private readonly IDeletableEntityRepository<Testimonial> testimonialRepo;
        private readonly IDeletableEntityRepository<Project> projectRepo;

        public TestimonialsService(
            IDeletableEntityRepository<Testimonial> testimonialRepo,
            IDeletableEntityRepository<Project> projectRepo)
        {
            this.testimonialRepo = testimonialRepo;
            this.projectRepo = projectRepo;
        }

        public async Task CreateAsync(CreateTestimonialInputModel input, Project project)
        {
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
            };
            await this.testimonialRepo.AddAsync(testimonial);
            await this.testimonialRepo.SaveChangesAsync();

            project.Testimonial = testimonial;
            await this.projectRepo.SaveChangesAsync();
        }
    }
}
