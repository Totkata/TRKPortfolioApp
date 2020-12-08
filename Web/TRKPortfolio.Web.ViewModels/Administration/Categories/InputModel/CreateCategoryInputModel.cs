namespace TRKPortfolio.Web.ViewModels.Administration.Categories.InputModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CreateCategoryInputModel
    {
        [Required]
        [StringLength(maximumLength: 250, MinimumLength = 5, ErrorMessage = "Lenght of the category name must be between 5 and 50 (Including) symbols!")]
        public string Name { get; set; }
    }
}
