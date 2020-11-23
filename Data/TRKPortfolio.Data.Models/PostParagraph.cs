namespace TRKPortfolio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PostParagraph
    {
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public int ParagraphId { get; set; }

        public virtual Paragraph Paragraph { get; set; }
    }
}
