namespace TRKPortfolio.Web.ViewModels.Administration.Skills.InputModel
{
    using System.ComponentModel.DataAnnotations;

    public class CreateSkillInputModel
    {
        [Required]
        public string Name { get; set; }
    }
}
