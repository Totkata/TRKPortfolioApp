namespace TRKPortfolio.Web.ViewModels.Administration.Categories.InputModel
{
    using System.ComponentModel.DataAnnotations;

    public class CreateCategoryInputModel
    {
        [Required]
        public string Name { get; set; }
    }
}
