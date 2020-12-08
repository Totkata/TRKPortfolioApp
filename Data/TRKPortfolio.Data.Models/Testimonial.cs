namespace TRKPortfolio.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using TRKPortfolio.Data.Common.Models;

    public class Testimonial : BaseDeletableModel<int>
    {
        [Required]
        [StringLength(maximumLength: 1000, MinimumLength = 100)]
        public string Text { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
