namespace TRKPortfolio.Web.ViewModels.Administration.Paragraphs.InputModel
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class ParagraphsInputModel
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 50 characters (include)!")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(int.MaxValue, MinimumLength = 100, ErrorMessage = "Content text must be at least 100 characters")]
        public string Content { get; set; }

        public IFormFile Attachment { get; set; }
    }
}
