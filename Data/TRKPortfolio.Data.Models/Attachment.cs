namespace TRKPortfolio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TRKPortfolio.Data.Common.Models;

    public class Attachment : BaseDeletableModel<string>
    {
        public Attachment()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ParagraphAttachments = new HashSet<ParagraphAttachment>();
            this.ProjectAttachments = new HashSet<ProjectAttachment>();
            this.TestimonialAttachments = new HashSet<TestimonialAttachment>();
        }

        public string Extention { get; set; }

        public virtual ICollection<ParagraphAttachment> ParagraphAttachments { get; set; }

        public virtual ICollection<ProjectAttachment> ProjectAttachments { get; set; }

        public virtual ICollection<TestimonialAttachment> TestimonialAttachments { get; set; }
    }
}
