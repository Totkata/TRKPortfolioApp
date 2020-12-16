namespace TRKPortfolio.Web.ViewModels.Administration.Posts.InputModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using TRKPortfolio.Web.ViewModels.Administration.Paragraphs.InputModel;

    public class CreatePostInputModel
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 60 (including) symbols!")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(500, MinimumLength = 25, ErrorMessage = "Description must be between 25 and 500 symbols!")]
        public string Description { get; set; }

        public IEnumerable<ParagraphsInputModel> Paragraphs { get; set; }

        [Required]
        public int[] CategoryId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }

        [Required]
        public IFormFile Thumbnail { get; set; }
    }
}
