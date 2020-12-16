namespace TRKPortfolio.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TRKPortfolio.Data.Common.Models;

    public class Paragraph : BaseDeletableModel<int>
    {
        public Paragraph()
        {
            this.ProjectParagraphs = new HashSet<ProjectParagraph>();
            this.PostParagraphs = new HashSet<PostParagraph>();
        }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 60 (including) symbols!")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(int.MaxValue, MinimumLength = 100, ErrorMessage = "Content must be at least 100 symbols!")]
        public string Content { get; set; }

        public string Path { get; set; }

        public ParagraphAttachment Attachment { get; set; }

        public virtual ICollection<ProjectParagraph> ProjectParagraphs { get; set; }

        public virtual ICollection<PostParagraph> PostParagraphs { get; set; }
    }
}
