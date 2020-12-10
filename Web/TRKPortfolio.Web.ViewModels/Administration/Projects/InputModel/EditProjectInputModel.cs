namespace TRKPortfolio.Web.ViewModels.Administration.Projects.InputModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class EditProjectInputModel
    {
        private const string TitleErrorMessage = "Title must be between 5 and 30 (including) symbols!";
        private const string DescriptionErrorMessage = "Description must be between 50 and 250 symbols!";
        private const string ContentInputErrorMessage = "Content text must be at least 100 symbols!";

        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(30, MinimumLength = 5, ErrorMessage = TitleErrorMessage)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(250, MinimumLength = 50, ErrorMessage = DescriptionErrorMessage)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(int.MaxValue, MinimumLength = 100, ErrorMessage = ContentInputErrorMessage)]
        public string Text { get; set; }

        [Required]
        public int[] CategoryId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }

        [Required]
        public int[] SkillId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Skills { get; set; }
    }
}
