namespace TRKPortfolio.Web.ViewModels.Testimonials.InputModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TRKPortfolio.Data.Models;
    using TRKPortfolio.Services.Mapping;
    using TRKPortfolio.Web.ViewModels.Testimonials.ViewModel;

    public class CreateTestimonialInputModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string CurrentTestimonial { get; set; }
    }
}
