namespace TRKPortfolio.Web.ViewModels.Administration.Projects.InputModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using TRKPortfolio.Web.ViewModels.Administration.Paragraphs.InputModel;

    public class CreateProjectInputModel
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 30 (including) symbols!")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(250, MinimumLength = 50, ErrorMessage = "Description must be between 50 and 250 symbols!")]
        public string Description { get; set; }

        public ICollection<ParagraphsInputModel> Paragraphs { get; set; }

        [Required]
        public int[] CategoryId { get; set; } // ToDo: Make to select many from dropDown menu!!!

        // View part
        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }

        [Required]
        public int[] SkillId { get; set; }

        // View part
        public IEnumerable<KeyValuePair<string, string>> Skills { get; set; }

        [Required]
        public string CustomerId { get; set; }

        // View part
        public IEnumerable<KeyValuePair<string, string>> Customers { get; set; }

        public IEnumerable<IFormFile> Attatchments { get; set; }
    }
}
