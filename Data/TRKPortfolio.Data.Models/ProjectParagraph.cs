namespace TRKPortfolio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProjectParagraph
    {
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public int ParagraphId { get; set; }

        public virtual Paragraph Paragraph { get; set; }
    }
}
