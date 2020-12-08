namespace TRKPortfolio.Web.ViewModels.Testimonials.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TRKPortfolio.Data.Models;
    using TRKPortfolio.Services.Mapping;

    public class TestimonialViewModel : IMapFrom<Testimonial>
    {
        public string Text { get; set; }
    }
}
