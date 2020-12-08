namespace TRKPortfolio.Web.ViewModels.Administration.Skills.InputModel
{
    using System.ComponentModel.DataAnnotations;

    public class CreateSkillInputModel
    {
        [Required]
        [StringLength(maximumLength: 250, MinimumLength = 5, ErrorMessage = "Lenght of the skill name must be between 5 and 50 (Including) symbols!")]
        public string Name { get; set; }
    }
}
