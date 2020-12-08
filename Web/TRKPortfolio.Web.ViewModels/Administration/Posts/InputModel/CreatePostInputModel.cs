namespace TRKPortfolio.Web.ViewModels.Administration.Posts.InputModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class CreatePostInputModel
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 100 (including) symbols!")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(500, MinimumLength = 50, ErrorMessage = "Description must be between 50 and 500 symbols!")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(int.MaxValue, MinimumLength = 250, ErrorMessage = "Content text must be at least 250 symbols!")]
        public string Text { get; set; }

        [Required]
        public int[] CategoryId { get; set; }

        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "At least one image is required")]
        public IEnumerable<IFormFile> Attatchments { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }
    }
}
