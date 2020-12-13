namespace TRKPortfolio.Web.ViewModels.Administration.Paragraphs.InputModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ParagraphsInputModel
    {
        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Error")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(int.MaxValue, MinimumLength = 100, ErrorMessage = "Error")]
        public string Content { get; set; }
    }
}
