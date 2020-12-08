namespace TRKPortfolio.Web.ViewModels.Testimonials.InputModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using TRKPortfolio.Data.Models;
    using TRKPortfolio.Services.Mapping;

    public class CreateTestimonialInputModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 1000, MinimumLength = 100, ErrorMessage = "Lenght of the testimonial text must be between 100 and 1000 (Including) symbols!")]
        public string Text { get; set; }
    }
}
