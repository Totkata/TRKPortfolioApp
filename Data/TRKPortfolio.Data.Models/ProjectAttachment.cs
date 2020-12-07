namespace TRKPortfolio.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProjectAttachment : AttachmentBaseModel
    {
        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
