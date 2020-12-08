namespace TRKPortfolio.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using TRKPortfolio.Data.Common.Models;

    public class Skill : BaseDeletableModel<int>
    {
        [Required]
        [StringLength(maximumLength: 250, MinimumLength = 5)]
        public string SkillTitle { get; set; }
    }
}
