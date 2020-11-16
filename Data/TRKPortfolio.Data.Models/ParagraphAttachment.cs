namespace TRKPortfolio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ParagraphAttachment
    {
        public int ParagraphId { get; set; }

        public virtual Paragraph Paragraph { get; set; }

        public string AttachmentId { get; set; }

        public Attachment Attachment { get; set; }
    }
}
