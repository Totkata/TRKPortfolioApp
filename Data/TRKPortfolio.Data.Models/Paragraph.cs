namespace TRKPortfolio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TRKPortfolio.Data.Common.Models;

    public class Paragraph : BaseDeletableModel<int>
    {
        public Paragraph()
        {
            this.ProjectParagraphs = new HashSet<ProjectParagraph>();
            this.PostParagraphs = new HashSet<PostParagraph>();
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public virtual ICollection<ProjectParagraph> ProjectParagraphs { get; set; }

        public virtual ICollection<PostParagraph> PostParagraphs { get; set; }
    }
}
