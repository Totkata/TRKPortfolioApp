namespace TRKPortfolio.Web.ViewModels.Administration.Posts.InputModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Microsoft.AspNetCore.Http;

    public class CreatePostInputModel
    {
        private const string TitleErrorMessage = "Title must be between 5 and 30 (including) symbols!";
        private const string DescriptionErrorMessage = "Description must be between 50 and 250 symbols!";
        private const string ContentInputErrorMessage = "Content text must be at least 100 symbols!";

        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = TitleErrorMessage)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(500, MinimumLength = 50, ErrorMessage = DescriptionErrorMessage)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(int.MaxValue, MinimumLength = 100, ErrorMessage = ContentInputErrorMessage)]
        public string Text { get; set; }

        [Required]
        public int[] CategoryId { get; set; } // ToDo: Make to select many from dropDown menu!!!

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }

        public IEnumerable<IFormFile> Attatchments { get; set; }
    }
}
