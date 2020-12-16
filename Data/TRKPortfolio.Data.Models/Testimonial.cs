namespace TRKPortfolio.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using TRKPortfolio.Data.Common.Models;

    public class Testimonial : BaseDeletableModel<int>
    {
        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(325, MinimumLength = 100, ErrorMessage = "Testimonial must be between 100 and 325 symbols!")]
        public string Text { get; set; }

        public virtual Rating Rating { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
