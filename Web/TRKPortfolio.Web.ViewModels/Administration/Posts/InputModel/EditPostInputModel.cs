namespace TRKPortfolio.Web.ViewModels.Administration.Posts.InputModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using TRKPortfolio.Web.ViewModels.Administration.Paragraphs.InputModel;
    using TRKPortfolio.Web.Views.Paragraphs.ViewModel;

    public class EditPostInputModel
    {
        private const string TitleErrorMessage = "Title must be between 5 and 30 (including) symbols!";
        private const string DescriptionErrorMessage = "Description must be between 50 and 250 symbols!";
        private const string ContentInputErrorMessage = "Content text must be at least 100 symbols!";

        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = TitleErrorMessage)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(500, MinimumLength = 50, ErrorMessage = DescriptionErrorMessage)]
        public string Description { get; set; }

        public IEnumerable<ParagraphsInputModel> Paragraphs { get; set; }

        public IEnumerable<PostParagraphViewModel> ParagraphsVm { get; set; }

        [Required]
        public int[] CategoryId { get; set; } // ToDo: Make to select many from dropDown menu!!!

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }
    }
}
