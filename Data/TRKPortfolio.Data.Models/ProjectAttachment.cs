namespace TRKPortfolio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProjectAttachment
    {
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public string AttachmentId { get; set; }

        public Attachment Attachment { get; set; }
    }
}
