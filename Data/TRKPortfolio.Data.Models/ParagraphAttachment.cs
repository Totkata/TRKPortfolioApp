namespace TRKPortfolio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ParagraphAttachment : AttachmentBaseModel
    {
        public int ParagraphId { get; set; }

        public Paragraph Paragraph { get; set; }
    }
}
