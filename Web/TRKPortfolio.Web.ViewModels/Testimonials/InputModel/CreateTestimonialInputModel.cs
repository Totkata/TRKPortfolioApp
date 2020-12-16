namespace TRKPortfolio.Web.ViewModels.Testimonials.InputModel
{
    using System.ComponentModel.DataAnnotations;

    public class CreateTestimonialInputModel
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(500, MinimumLength = 100, ErrorMessage = "Testimonial must be between 100 and 325 symbols!")]
        public string Text { get; set; }

        public string CurrentTestimonial { get; set; }
    }
}
