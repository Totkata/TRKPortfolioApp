namespace TRKPortfolio.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using TRKPortfolio.Data.Models;
    using TRKPortfolio.Web.ViewModels.Testimonials.InputModel;

    public interface ITestimonialsService
    {
        Task CreateAsync(CreateTestimonialInputModel input);
    }
}
